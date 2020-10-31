// StringCharacterCount.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

extern "C" int CountChar(wchar_t* text, wchar_t character);

int main()
{
    wchar_t c;
    wchar_t* s;
    s = (wchar_t *) L"Assembler Hello World!";
    c = L'r';

    wprintf(L"Test string: %s\n", s);
    wprintf(L"Search character: %c, Count: %d\n", c, CountChar(s, c));

    return 0;
}