// ArrayReverser.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

extern "C" void Reverser(int* y, const int* x, int n);

int main()
{

    const int n = 10;
    int x[n], y[n];

    srand(41);

    for (int i = 0; i < n; i++) {
        x[i] = rand() % 1000;
    }

    Reverser(y, x, n);

    for (int i = 0; i < n; i++) {
        std::cout << x[i] << "\t";
    }
    
    std::cout << std::endl;

    for (int i = 0; i < n; i++) {
        std::cout << y[i] << "\t";
    }
}