// CalcArrayCube.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

extern "C" int CalcArrayRowColSumASM(const int* x, int nrows, int ncols, int* row_sums, int* col_sums);

void CalcArrayCube(int* y, const int* x, int nrows, int ncols) {

	for (int i = 0; i < nrows; i++)
	{
		for (int j = 0; j < ncols; j++) {
			int k = i * ncols + j;
			y[k] = x[k] * x[k] * x[k];
		}
	}

}


void PrintArray(int* x, int nrows, int ncols, int* row_sums, int* col_sums) {

	for (int i = 0; i < nrows; i++)
	{
		for (int j = 0; j < ncols; j++) {

			int k = i * ncols + j;

			printf("%5d\t", x[k]);

		}

		printf(" \t%5d\n", row_sums[i]);
	}

	printf("\n");

	for (int i = 0; i < ncols; i++)
	{
		printf("%5d\t", col_sums[i]);
	}

}

int main()
{
	const int nrows = 4;
	const int ncols = 3;

	int x[nrows][ncols] = {
		{1,	 2,	 3},
		{4,	 5,	 6},
		{7,	 8,	 9},
		{10, 11, 12}
	};

	int row_sums[nrows];
	int col_sums[ncols];

	CalcArrayRowColSumASM((const int*)x, nrows, ncols, row_sums, col_sums);

	PrintArray(&x[0][0], nrows, ncols, row_sums, col_sums);


	//for (int i = 0; i < nrows; i++)
	//{
	//	for (int j = 0; j < ncols; j++) {

	//		//int k = i * ncols + j;

	//		printf("%5d\t", x[i][j]);

	//	}

	//	printf(" \t%5d\n", row_sums[i]);
	//}

	//printf("\n");

	//for (int i = 0; i < ncols; i++)
	//{
	//	printf("%5d\t", col_sums[i]);
	//}


	/*
	CalcArrayCube(&y[0][0], &x[0][0], nrows, ncols);

	for (int i = 0; i < nrows; i++)
	{
		for (int j = 0; j < ncols; j++) {
			int k = i * ncols + j;

			printf("(%2d, %2d) : %6d, %6d\n", i, j, x[i][j], y[i][j]);

		}
	}
	*/


	return 0;
}