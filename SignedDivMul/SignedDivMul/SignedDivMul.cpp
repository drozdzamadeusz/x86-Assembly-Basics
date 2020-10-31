// SignedDivMul.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

extern "C" int IntegerDivMul(int a, int b, int* prod, int* quo, int* rem);

int main()
{

    int a = 21, b = 0;
    int prod = 0, quo = 0, rem = 0;

    int rv = IntegerDivMul(a, b, &prod, &quo, &rem);

    std::cout <<"Result: "<< rv << " Product: "<<prod<<" Quotient: "<<quo<<" Reminer: "<<rem;
}
