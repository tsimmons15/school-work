#include <iostream>
#include <fstream>
using namespace std;

int main()
{
 	int powers = 0;
 	int prior = 1;
 	char cont = ' ';
 	
 	do
 	{    cout << "How many powers of 2 do you want to be displayed? ";
 		 cin >> powers;
 		 cout << cont;
 	
         while (powers < 1 || powers > 10)
 	     {
              cout << powers << " is not a valid number." << endl;
			  cout << "Enter a number between 1 and 10: ";
         	  cin >> powers;
         }
         
         prior = 1;
    	 for (int x = 1; x <= powers; x++)
    	 {
              prior = (prior)*2;
	     	  cout << "2 to the " << x << " power = " << prior << endl;
         }
         cout << "Do you wish to continue?" << endl;
         cout << "[Y]es or [N]o: ";
         cin >> cont;
         cont = tolower(cont);
     } while (cont == 'y');

	system("pause");
	
	return 0;
}
