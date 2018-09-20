#include <iostream>

using namespace std;

int& TestReference()
{
	int b = 10;
	int& a = b;
	return a;
}

int main1()
{
	int a = 1;
	int& b = TestReference();
	b = 1;
	int c = TestReference();
	printf("b:%d\nc:%d\n", b, c);
	system("pause");
	return 0;
}

int main2()
{
	string str = NULL;
	str.append("123");
	system("pause");
	return 0;
}
