// TestDll.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"


extern "C" __declspec(dllexport)
 int __stdcall add(int a, int b)
{
	return a + b;
}

extern "C" __declspec(dllexport)
int __cdecl add1(int a, int b)
{
	return a + b;
}