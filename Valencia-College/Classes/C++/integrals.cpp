// The Integral

#include <algorithm>
#include <iomanip>
#include <ios>
#include <iostream>
#include <stdexcept>
#include <iomanip>

using namespace std;  

#define wait for (int asd = 0; asd < 30000000; asd++);
#define PARTITIONS 1500000

double integration(int left, int right, double n);
double func (double x);

int main () 
{   
	double total = 0;
    cout << "Please enter left and right bounds: ";
    int left, right;
    cin >> left >> right;
    for(double i = 10; i < PARTITIONS; i += i  + 1)
    {
       total = integration(left, right, i);
    }
    
    cout << "The integral is: " << total << endl;
    system("pause");
    return 0;
}

double func (double x) 
{
    return (x>0)?x:-x;
}

double integration(int left, int right, double n)
{

    double width = (double)(right - left) / n;
    double total = 0;

    for (int i = 0; i < n; ++i) {
        total += (func(left + (width * i)) * width);
    }
	return total;
}
