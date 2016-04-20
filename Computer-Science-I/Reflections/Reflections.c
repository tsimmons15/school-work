//Timothy Simmons
//NID - ti812979

#include <stdio.h>
#include <stdlib.h>
#include "Reflections.h"

//A function to determine whether the trees rooted at a and b are
// reflections of one another, according to the definition of reflection
// This must be implemented recursively.
//   Returns: 1 if the trees are reflections of one another, 0 otherwise.
int isReflection(node *a, node *b)
{
	int isReflected = 1;
	if (a == NULL && b == NULL)
		return 1;//The trees ended at same length, return true
	else if (a == NULL || b == NULL)
		return 0;//The trees have different lengths, can't be reflections
	//In a reflection, the root/subroot is the same
	isReflected = a->data == b->data;
	//Test whether the a-left and b-right subtrees are reflections
	// The result is &&'d together with the previous results so 
	// false values will dominate
	isReflected &= isReflection(a->left, b->right);
	//Same as above but test from a-right and b-left, the opposite
	isReflected &= isReflection(a->right, b->left);
	
	//Return whether the trees are reflections or not
	return isReflected;
}



//A function that creates a new tree, which is a reflection of the tree
// rooted at root. This function must create an entirely new tree in memory.
// As your function creates a new tree, it must not destroy or alter the
//  structure or values in the tree that was to it as a parameter.
// Tampering with the tree rooted at root will cause test case failure.
//    Returns: A pointer to the root of the new tree. (This implies.
//     of course, that all the nodes in the new tree must be dynamically
//		allocated.)
node *makeReflection(node *root)
{
	node *reflection;

	if (root == NULL)
		return NULL;
	//Create a root node
	reflection = calloc(1, sizeof(node));
	//Since the roots of reflected trees are the same, 
	// set this new root to old root's value
	reflection->data = root->data;
	//Set the new left subtree to the values in the old right subtree.	
	reflection->left = makeReflection(root->right);
	// Same as above, but right from left
	reflection->right = makeReflection(root->left);

	return reflection;
}


//Granted, I didn't do much thorough testing, so it might be
// the confidence of ignorance.
double difficultyRating(void)
{
	return 2;
}
double hoursSpent(void)
{
	return 0.3;
}


