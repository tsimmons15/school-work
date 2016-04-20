#include <stdio.h>
#include <stdlib.h>

typedef struct 
{
	int value;
	struct NODE *next;
} NODE;

NODE *createNode(int value)
{
	NODE *nd;
	nd=(NODE*) malloc(sizeof(NODE));
	if(nd==NULL){
		fprintf(stderr, "Error: not enough memory. \n");
		return NULL;
	}
	nd->value=value;
	nd->next=NULL;
	return nd;
}

void sortlist(NODE *nd1,int NOE){
	int c, temp;
	NODE *currNd = nd1;
	NODE *previous;
	NODE *after = currNd->next;
	char swap = 'n';

	for(c=1;c<=NOE-1;c++)
	{
		
		if(currNd->value > after->value)
		{
			previous = nd1;
			
		     while(after->value>previous->value)
			 {
			 	previous = previous->next;
			 }

			 while (previous->value != after->value)
			 {
				temp = after->value;
				after->value = previous->value;
				previous->value = temp;

				previous = previous->next;
			 }
		}
		if (currNd->next != NULL)
		{
			currNd = currNd->next;
			after = currNd->next;
		}
	}
}
int main()
{
	
	int NOE,n,x,d,c;
	
	FILE *list;
	char *mode="r";
	NODE *nd1;
	NODE *currNd;
	list = fopen("list.txt",mode);
	fscanf(list,"%d",&NOE);
	
	fscanf(list,"%d",&n);
	nd1 = createNode(n);
	fscanf(list,"%d",&n);
	currNd = createNode(n);
	nd1->next = currNd;
	
	//loop
	for(x=1;x<NOE-1;x++)
	{
		fscanf(list,"%d", &n);
		currNd->next = createNode(n);
		currNd = currNd->next;
	}	
	
	sortlist(nd1, NOE);
	printf("The Sorted List:\n");
	printf("%d,", nd1->value);
	currNd= nd1->next;
	for(x=1;x<NOE;x++)
	{
		printf("%d%c",currNd->value, (x == (NOE-1) ? ' ': ','));
		currNd = currNd->next;
		
	}	
	
	
	system("pause");
	return 0;
}
