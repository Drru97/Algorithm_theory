#include "stdafx.h"
#include <iostream>

#define INF 999
#define MatrixLen 4

/* Weight matrix */
int matrix[MatrixLen][MatrixLen] =
{
	{ 0, -2, 3, -3},
	{ INF, 0, 2, INF},
	{ INF, INF, 0, -3},
	{ 4, 5, 5, 0},
};

int thetha[MatrixLen][MatrixLen];

void printMatrix()
{
	std::cout << std::endl;
	for (size_t i(0); i < MatrixLen; ++i)
	{
		for (size_t j(0); j < MatrixLen; ++j)
			std::cout << matrix[i][j] << " \t";
		std::cout << std::endl;
	}
	std::cout << std::endl;
}
int main()
{
	/* Finding minimum path from one point to anothers */

	/* Initializing matrix thetha */
	for (size_t i(0); i < MatrixLen; ++i)
		for (size_t j(0); j < MatrixLen; ++j)
			if (i != j)
				thetha[i][j] = i;
			else
				thetha[i][j] = 0;

	for (size_t k(0); k < MatrixLen; ++k)
	{
		/* Matrix omega */
		for (size_t i(0); i < MatrixLen; ++i)
			for (size_t j(0); j < MatrixLen; ++j)
				if (matrix[i][k] < INF && matrix[k][j] < INF)
					if (matrix[i][k] + matrix[k][j] < matrix[i][j])
						matrix[i][j] = matrix[i][k] + matrix[k][j];
		/* Matrix thetha */
		for (size_t i(0); i < MatrixLen; ++i)
			for (size_t j(0); j < MatrixLen; ++j)
				if (matrix[i][j] == matrix[i][k] + matrix[k][j])
					thetha[i][j] = thetha[k][j];

		std::cout << "Iteration " << k;
		printMatrix();
	}
	int from = 0;
	int to = 4;
	std::cout << "Path length from " << from << " to " << to << " is " << matrix[from][to] << std::endl;
	system("pause");
	return 0;
}