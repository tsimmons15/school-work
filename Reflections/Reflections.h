#ifndef __REFLECTIONS_H
#define __REFLECTIONS_H

typedef struct node
{
	// each node holds a single integer
	int data;

	// pointers to the node's left and right children
	struct node *left, *right;
} node;


// Functional Prototypes

int isReflection(node *a, node *b);

node *makeReflection(node *root);

double difficultyRating(void);

double hoursSpent(void);

#endif
