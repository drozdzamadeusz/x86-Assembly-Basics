// CalculateSum.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

extern "C" int AdderASM(int a, int b, int c);

int main()
{
    int a = 20, b = 20, c = 20;

    int sum = AdderASM(a, b, c);

    std::cout << "Sum: " << sum;
}