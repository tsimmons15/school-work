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
        printf("%d%c ", arr[i], ((i+1) == SIZE) ? ' ' : ',');
    printf("\n");

    return;
}

void processArray(int *arr)
{
    int i = 0, maximum = 0, second_max = 0;
    for (i = 0; i < SIZE; i++)
    {
        if (arr[i] > maximum)
        {
            second_max = maximum;
            maximum = arr[i];
        }
        else if (arr[i] > second_max && arr[i] != maximum)
        {
            second_max = arr[i];
        }
    }

    printf("Maximum value: %d\n", maximum);
    printf("Second largest value: %d\n", second_max);

    return;
}
