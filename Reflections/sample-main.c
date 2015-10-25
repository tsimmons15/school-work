// Sean Szumlanski
// COP 3502, Fall 2015
//
// sample-main.c
// =============
// Sample main() function for Assignment #4: Reflections.
#include <stdio.h>
#include <stdlib.h>
#include "Reflections.h"


// A pretty standard createNode() function. Creates a new binary tree node,
// initializes its members, and returns a pointer to the new node.
node *createNode(int data)
{
	node *n = malloc(sizeof(node));

	n->data = data;
	n->left = n->right = NULL;

	return n;
}

// Sample main() function. Plunk this into your code along with my createNode()
// function to see whether your program passes a few basic unit tests. In
// testing, I will try to name any helper functions of mine (like createNode())
// something more obscure, so you don't have to worry about whether you 
int main(void)
{
	node *root1, *root2, *root3, *root4, *node1, *node2, *node3;

	// Let's build a tree! This is a super hacky and terrible way of making the
	// left binary tree from Figure 1 in the assignment PDF. Please don't ever
	// do anything this terrible, hacky, and inelegant in your code.
	root1 = createNode(10);
	root1->left = createNode(20);
	root1->right = createNode(30);
	root1->right->left = createNode(40);
	root1->right->right = createNode(1);

	// Construct the reflection of the tree, and ensure that that the
	// isReflection() function works.
	if (isReflection(root1, root2 = makeReflection(root1)))
	{
		printf("Success!\n");
	}
	else
	{
		printf("Fail whale!\n");
	}

	// This is a very direct and hacky-horrible way of checking the tree's
	// structure manually, just in case I don't trust your isReflection() code.
	if (// Check root node
	    root2->data == 10 &&
	    root2->left != NULL &&
	    root2->right != NULL &&

	    // Check node 20
	    root2->right->data == 20 &&
	    root2->right->left == NULL &&
	    root2->right->right == NULL &&

	    // Check node 30
	    root2->left->data == 30 &&
	    root2->left->left != NULL &&
	    root2->left->right != NULL &&

	    // Check node 1
	    root2->left->left->data == 1 &&
	    root2->left->left->left == NULL &&
	    root2->left->left->right == NULL &&

	    // Check node 40
	    root2->left->right->data == 40 &&
	    root2->left->right->left == NULL &&
	    root2->left->right->right == NULL)
	{
		printf("Success!\n");
	}
	else
	{
		printf("Fail whale!\n");
	}

	// Let's establish some trees with just a single element.
	node1 = createNode(15);
	node2 = createNode(15);
	node3 = createNode(14);
	
	if (isReflection(node1, node2))
	{
		printf("Success!\n");
	}
	else
	{
		printf("Fail whale!\n");
	}

	// Compare the single-node tree with itself.
	if (isReflection(node1, node1))
	{
		printf("Success!\n");
	}
	else
	{
		printf("Fail whale!\n");
	}

	// Create a reflection of a single node and compare it to itself.
	node3 = makeReflection(node1);
	if (isReflection(node3, node1))
	{
		printf("Success!\n");
	}
	else
	{
		printf("Fail whale!\n");
	}

	// Compare two empty trees. They should be reflections (by definition; see
	// pg. 4 of the assignment PDF).
	if (isReflection(NULL, NULL))
	{
		printf("Success!\n");
	}
	else
	{
		printf("Fail whale!\n");
	}

	// This is a rather round-about way of passing two empty trees to the
	// isReflection() function.
	if (isReflection(makeReflection(NULL), NULL))
	{
		printf("Success!\n");
	}
	else
	{
		printf("Fail whale!\n");
	}

	// Empty tree vs. non-empty tree. These should not be reflections of one
	// another.
	if (!isReflection(NULL, root2))
	{
		printf("Success!\n");
	}
	else
	{
		printf("Fail whale!\n");
	}

	// Let's create a slightly more complex tree. This is the tree from
	// Figure 4 in the assignment PDF. This approach is super hacky and
	// terrible, and you should never do something like this!
	root3 = createNode(2);
	root3->left = createNode(14);
	root3->right = createNode(14);
	root3->left->left = createNode(62);
	root3->left->right = createNode(62);
	root3->right->left = createNode(62);
	root3->right->right = createNode(62);
	root3->left->left->left = createNode(34);
	root3->left->left->right = createNode(34);
	root3->left->right->left = createNode(34);
	root3->left->right->right = createNode(34);
	root3->right->left->left = createNode(34);
	root3->right->left->right = createNode(34);
	root3->right->right->left = createNode(34);
	root3->right->right->right = createNode(34);

	root4 = makeReflection(root3);
	if (isReflection(root3, root4))
	{
		printf("Success!\n");
	}
	else
	{
		printf("Fail whale!\n");
	}
	
	// Verify that the hoursSpent() function is return a valid value, given
	// the range restriction in the assignment PDF.
	if (hoursSpent() <= 0.0)
	{
		printf("The return value of your hoursSpent() function is out of range.\n");
	}

	// Verify that the difficultyRating() function is return a valid value, given
	// the range restriction in the assignment PDF.
	if (difficultyRating() < 1.0 || difficultyRating() > 5.0)
	{
		printf("The return value of your difficultyRating() function is out of range.\n");
	}

	// This is super naughty, but... I decline to free the dynamically
	// allocated memory here.

	return 0;
}
