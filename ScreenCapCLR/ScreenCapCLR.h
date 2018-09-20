#pragma once

#include "ScreenRecorder.h"
#include "RecordInfo.h"
using namespace System;

namespace ScreenCapCLR 
{
	public ref class ScreenCapHelper
	{
		// TODO: 在此处添加此类的方法。
	public:
		ScreenCapHelper();
		ScreenCapHelper(RecordSettingInfo^ recordInfo, ICallbackSIO^ callBack);
		int add(int a, int b);
		void testPrint()
		{
			m_screenRecorder->testPrint();
		}

		void StartRecord();

		void StopRecord();

		void SetRecordSettingInfo(RecordSettingInfo^ recordInfo);

		void SetCallBack(ICallbackSIO^ callBack);

	private:
		ScreenRecorder^ m_screenRecorder;
	};

}


