#include <stdio.h>
#include <time.h>

#define SIZE 10
#define MAX 5
#define MIN 1
void fillArray(int *arr);
void displayArray(int *arr);
void processArray(int *arr);

int main()
{
    int arr[SIZE] = {0};
    int i = 0, key = 0, occurences = 0;

    fillArray(arr);
    displayArray(arr);
    processArray(arr);
    return 0;
}


void fillArray(int *arr)
{
    int i = 0;
    srand(time(NULL));
    for (i = 0; i < SIZE; i++)
        arr[i] = rand() % MAX + MIN;

    return;
}

void displayArray(int *arr)
{
    int i = 0;
    printf("Array data\n");
    for (i = 0; i < SIZE; i++)
        printf("%d%c ", arr[i], ((i+1) == SIZE) ?  ' ' : ',');
    printf("\n");

    return;
}

void processArray(int *arr)
{
    int i = 0, index = 0, key = 0, occurrences = 0;
    printf("Enter the key: ");
    scanf("%d", &key);

    for (i = 0; i < SIZE; i++)
    {
        if (arr[i] == key)
        {
            if (occurrences == 0)
                printf("First occurrence at index: %d\n", i);
            else
                index = i;
            occurrences++;
        }
    }
    if (index > 0)
        printf("Last occurrence at index: %d\n", index);
    printf("Total number of occurrences: %d\n", occurrences);

    return;
}
