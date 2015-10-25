// Timothy Simmons
// ti812979

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "ListyString.h"

#define STRING_MAX 1024
//OPERATOR INDEX, the index which the operator is expected to be found at
#define OP_INDEX 0
//KEY_INDEX, the index which the key is expected to be found at
#define KEY_INDEX 2
//STR_OFFSET, the offset expected to get to the replacing string
#define STR_OFFSET 4

node *headInsert(node *head, char c)
{
	node *temp;
	temp = malloc(sizeof(node));
	temp->data = c;
	temp->next = head;

	return temp;
}

node *destroyList(node *head)
{
	node *temp;
	while (head != NULL)
	{
		temp = head;
		head = head->next;
		free(temp);
	}
	return head;
}

// Convert the string str to a linked list. If str is NULL 
// or an empty string (""), simply return NULL
node *stringToList(char *str)
{
	node *head = NULL;
	int i = 0, size = 0;

	if (str == NULL || str[0] == '\0')
		return NULL;

	//For convenience, allowing me to start at the end of the string
	size = strlen(str);

	//Head insert is O(1), which is beneficial. It has a side-effect of
	// reversing the inserted items. To counter, starting at end of string.
	for (i = (size - 1); i >= 0; i--)
	{
		if (str[i] == '\n')
			continue;
		head = headInsert(head, str[i]);
	}

	return head;
}

// Takes a linked list (head) and replaces all instances of a certain character (key)
// with the specified string (str). If str is NULL or the empty string (""), this
// function simply acts to delete all instances of key from the linked list. 
// If key does not occur anywhere in the linked list, the list remains unchanged.
node *replaceChar(node *head, char key, char *str)
{
	node *previous = NULL, *current = NULL;
	if (head == NULL)
		return NULL;
	
	previous = NULL;
	current = head;	
	
	while (current != NULL)
	{
		if (current->data == key)
		{
			//Either delete the node, or insert str list in its place
			if (str == NULL || str[0] == '\0')
			{
				//Delete node
				//If the to-be-deleted node is not the head
				if (current != head)
				{
					//Delete node
					previous->next = current->next;
					free(current);
					current = previous->next;
				}
				else
				{
					//Update head
					head = head->next;
					//Then delete node
					free(current);
					previous = NULL;
					current = head;
				}

			}
			else
			{
				//Insert str list in its place
				//Found an instance of key in the list
				//If the to-be-deleted node is not the head
				if (current != head)
				{

					//Delete node, insert str list
					previous->next = stringToList(str);
					//Move to the end of the newly deleted list
					while (previous->next != NULL)
					{
						previous = previous->next;
					}
					//Rejoin the two halves and delete node.
					previous->next = current->next;
					free(current);
					current = previous->next;
				}
				else
				{
					//To-be-deleted node is head, so insert str list at head
					previous = head;					
					current = head->next;
					head = stringToList(str);
					free(previous);
					previous = head;
					while (previous->next != NULL)
					{
						previous = previous->next;
					}
					//Rejoin two halves
					previous->next = current;					
				}
			}
		}
		
		//Check for two things:
		// That my next isn't null, which means I am at the end of the list
		// Also that my current->data doesn't still point to an instance of key
		// 	Mainly to handle situations such as (key)->(key)->(A-Za-z0-9)
		if (current != NULL && current->data != key)
		{
			previous = current;
			current = current->next;
		}
	}

	return head;
}

//Reverse the linked list
node *reverseList(node *head)
{
	node *temp = NULL, *storage = NULL;

	while (head != NULL)
	{
		//Taking advantage of the fact that head-insertion tends to reverse lists.
		temp = headInsert(temp, head->data);
		

		//Release the head address, after moving head down.
		storage = head;
		head = head->next;
		free(storage);
		storage = NULL;
	}
	return temp;
}

// Print the string stored in the linked list, followed by a newline character, '\n'.
// If head is NULL, simply print "(empty string)" (without the quotes), followed by
// a newline character, '\n'
void printList(node *head)
{
	if (head == NULL)
	{
		printf("(empty string)\n");
	}
	else
	{
		while (head != NULL)
		{
			printf("%c", head->data);
			head = head->next;
		}
		printf("\n");
	}
}


int main(int argc, char **argv)
{
	node *head = NULL;
	FILE *f = NULL;
	int i = 0;
	char *string = NULL, c = 0;
	if (argc > 1)
	{
		f = fopen(argv[1], "r");
	}

	if (f == NULL)
		exit(-1);

	//Start the main purpose of the program
	//Initialize space for the string array
	string = calloc(STRING_MAX, sizeof(char));
	//Read string in from file:
	fgets(string, STRING_MAX, f);

	if (string == NULL || string[0] == '\0')
		exit(-1);

	//Removing trailing '\n'
	string[strlen(string)-1] = '\0';

	head = stringToList(string);

	while (fgets(string, STRING_MAX, f) != NULL)
	{
		switch (string[OP_INDEX])
		{
			case '!':
				printList(head);
				break;
			case '~':
				head = reverseList(head);
				break;
			case '-':
				//Remove key from list
				head = replaceChar(head, string[KEY_INDEX], NULL);
				break;
			case '@':
				string[strlen(string) - 1] = '\0';
				//Insert string into list
				head = replaceChar(head, string[KEY_INDEX], string+STR_OFFSET);
				break;
			default:
				break;
		}
	}
	fclose(f);
	free(string);
	head = destroyList(head);
	
    return 0;
}
