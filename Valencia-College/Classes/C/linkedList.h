typedef struct 
{
	int value;
	struct NODE *next;
} NODE;

typedef struct
{
    int value;
	struct Node *next;
	struct Node *last;
} Node;

typedef struct
{
    int *values;
	struct Node *next;
} ArrayList;

void printList(NODE *list)
{
	NODE *head = list;
	int i = 1;

	while (head != NULL)
	{
		printf("%5d.)%-5d", i, head->value);
		head = head->next;
		if (i % 5 == 0)
			printf("\n\n");
		i++;
	}

	printf("\n");
}

void highValue(NODE *list, int *high)
{
	NODE *current = list;
	*high = current->value;
	current = current->next;
	while (current != NULL)
	{
		if (current->value > *high)
		{
			*high = current->value;
		}
		current = current->next;
	}
}

void lowValue(NODE *list, int *low)
{
	NODE *current = list;
	*low = current->value;
	current = current->next;
	while (current != NULL)
	{
		if (current->value < *low)
		{
			*low = current->value;
		}
		current = current->next;
	}
}

void average(NODE *list, int *average)
{
	NODE *current = list;
	int count = 0;
	while (current != NULL)
	{
		*average += current->value;
		current = current->next;
		count++;
	}

	*average /= count;
}

NODE *createRandomNode()
{
	NODE *nd;
	int random;
	nd=(NODE*) malloc(sizeof(NODE));
	if(nd==NULL){
		fprintf(stderr, "Error: not enough memory. \n");
		system("pause");
		return NULL;
	}

	nd->value = rand() % SIZE;
    nd->next=NULL;
	
	return nd;
}

NODE *createEmptyNode()
{
	NODE *nd;
	nd=(NODE*) malloc(sizeof(NODE));
	if(nd==NULL){
		fprintf(stderr, "Error: not enough memory. \n");
		return NULL;
	}
	nd->value = 0;
	nd->next=NULL;
	return nd;
}

/*
	Since list changes in the function, and since pointers are just variables that store address locations
	pass as a pointer to a pointer, so we can update where the node points to back in main
	
	--This is the reason we were losing access to multiple values before: they were sorted to before the original
	  "head", and since the pointer back in main was never properly updated, it looked like some were lost.
*/
NODE *insertNode(NODE **list, NODE *after, NODE *current)
{
	NODE *stepOne = *list;
	NODE *stepTwo = NULL;
    while(after->value>stepOne->value)
	{
        stepTwo = stepOne;
		stepOne = stepOne->next;
	}
		     
	current->next = after->next;
	after->next = stepOne;
	if (stepTwo != NULL)
	{
		stepTwo->next = after;
	}
	if (stepOne == *list)
    {
       *list = after;
    }
}

/*
	Since list changes in the function, and since pointers are just variables that store address locations
	pass as a pointer to a pointer
*/

void sortList(NODE **list){
	int c = 0, temp;
	NODE *currNd = *list;
	NODE *stepOne = NULL;
	NODE *stepTwo = NULL;
	NODE *after = currNd->next;

	while (currNd->next != NULL)
	{
		while(currNd->value > after->value)
		{
			insertNode(list, after, currNd);
			if (currNd->next == NULL)
			{
				return;
			}
			after = currNd->next;
		}

			currNd = currNd->next;
			after = currNd->next;
			stepTwo = NULL;

	}
}

void standardDeviation(NODE *list, double *std)
{
	NODE *current = list;
	int avg = 0, count = 0;

	average(list, &avg);

	while (current->next != NULL)
	{
		(*std) += (current->value - avg) * (current->value - avg);
		current = current->next;
	}

	(*std) /= (SIZE - 1);
	(*std) = sqrt(*std);

}