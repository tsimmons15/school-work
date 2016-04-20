#include <stdio.h>

#define SIZE 10
#define MAX 10
#define MIN 1

void fillArray(int *arr);
void displayArray(int *arr);
void processArray(int *arr);

int main()
{
    int arr[SIZE] = {0};

    fillArray(arr);
    printf("Array data\n");
    displayArray(arr);
    processArray(arr);
    printf("After processing\n");
    displayArray(arr);

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
    //printf("Array data\n");
    for (i = 0; i < SIZE; i++)
        printf("%2d%c ", arr[i], ((i+1) == SIZE) ?  ' ' : ',');
    printf("\n");

    return;
}

void processArray(int *arr)
{
    int found[MAX] = {0};
    int i = 0;
    int index = 0;
    for (i = 0; i < SIZE; i++)
    {
        index = arr[i] - 1;
        if (found[index] == 0)
            found[index] = 1;
        else
            arr[i] = -1;
    }
    return;
}
