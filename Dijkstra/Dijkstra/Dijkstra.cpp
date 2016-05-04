#include "stdafx.h"
#include <iostream>
#include <conio.h>
#include <clocale>

#define word unsigned int

using namespace std;

int flag[11];  // labels
word c[11][11], l[11];  // weight matrix

int min(int n)
{
	int i, result;
	for (i = 0; i < n; i++)
		if (!(flag[i])) result = i;
	for (i = 0; i<n; i++)
		if ((l[result]>l[i]) && (!flag[i])) result = i;
	return result;
}

word minim(word x, word y)
{
	if (x < y) return x;
	return y;
}

int main()
{
	int i, j, n, p, xn, xk;
	char s[80], path[80][11];
	setlocale(LC_ALL, "Ukrainian");
	cout << "Input points quantity: ";
	cin >> n;
	for (i = 0; i < n; i++)
		for (j = 0; j < n; j++)
			c[i][j] = 0;
	for (i = 0; i < n; i++)
		for (j = i + 1; j < n; j++)
		{
			cout << " Input line length from  X" << i + 1 << " to X" << j + 1 << ": ";
			cin >> c[i][j];
		}
	cout << "   ";
	for (i = 0; i < n; i++)
		cout << "    X" << i + 1;
	cout << endl << endl;
	for (i = 0; i < n; i++)
	{
		printf("X%d", i + 1);
		for (j = 0; j < n; j++)
		{
			printf("%6d", c[i][j]);

			c[j][i] = c[i][j];
		}
		printf("\n\n");
	}
	for (i = 0; i < n; i++)
		for (j = 0; j < n; j++)
			if (c[i][j] == 0)
				c[i][j] = 65535; //infinite
	cout << " Input starting point: ";
	cin >> xn;
	cout << " Input ending point: ";
	cin >> xk;
	xk--;
	xn--;
	if (xn == xk)
	{
		cout << "Starting and ending points are the same" << endl;
		_getch();
		return 0;
	}
	/* Initializing */
	for (i = 0; i < n; i++)
	{
		flag[i] = 0;
		l[i] = 65535;
	}
	l[xn] = 0;
	flag[xn] = 1;
	p = xn;  // set begining point
	_itoa(xn + 1, s, 10);
	for (i = 1; i <= n; i++)
	{
		strcpy(path[i], "X");
		strcat(path[i], s);
	}
	do
	{
		for (i = 0; i < n; i++)
			if ((c[p][i] != 65535) && (!flag[i]) && (i != p))
			{
				if (l[i] > l[p] + c[p][i])
				{
					_itoa(i + 1, s, 10);
					strcpy(path[i + 1], path[p + 1]);
					strcat(path[i + 1], "-X");
					strcat(path[i + 1], s);
				}
				/* Updating labels */
				l[i] = minim(l[i], l[p] + c[p][i]);
			}
		/* Transform label into permanent */
		p = min(n);
		flag[p] = 1;
	} while (p != xk);
	/* Search for the shortest way */
	if (l[p] != 65535)
	{
		cout << "Path: " << path[p + 1] << endl;
		cout << "Path length: " << l[p] << endl;
	}
	else
		cout << "Path not exist" << endl;
	_getch();
	return 0;
}
