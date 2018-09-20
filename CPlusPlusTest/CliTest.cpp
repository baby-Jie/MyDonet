#include <iostream>
#include "Calculator.h"

using namespace std;
using namespace CppCliTest;
using namespace ClrTestDll;

int main()
{

	ClrTestDll::Calculator^ cal = gcnew ClrTestDll::Calculator();
	int a = cal->add(2, 3);
	printf("a is:%d\n", a);
	system("pause");
	return 0;
}