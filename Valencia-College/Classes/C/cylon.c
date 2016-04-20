#include <stdio.h>

int main()
{
	int x = 0;
	int i = 0, j = 0;

	int increasing = 1;
	int row = 0;
	char arr[] = { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', 0 };
	int size = sizeof(arr);
	i = size;

	printf("%d\n", size);

	system("pause");

	while (1)
	{

		if (increasing)
			i += 2;
		else
			i -= 2;

		if (i == 121 || i == (size-2))
		{
			increasing = !increasing;
			row++;
		}
		system("cls");

		//for (x = 0; x < row; x++)
			//printf("\n");

		printf("%*s\n", i, arr);
		printf("%*s\n", i, arr);
		printf("%*s\n", i, arr);
	}
	return 0;
}
