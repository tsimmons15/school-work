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
        printf("%d%c ", arr[i], ((i+1) == SIZE) ?  ' ' : ',');
    printf("\n");

    return;
}

void processArray(int *arr)
{
    int i = 0, j = SIZE/2, temp = 0;
    j += ((SIZE % 2) == 0) ? 0 : 1;
    for (i = 0; j < SIZE; i++, j++)
    {
        temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    return;
}
