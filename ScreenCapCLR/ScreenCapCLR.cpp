#include "stdafx.h"
#include "ScreenCapCLR.h"

namespace ScreenCapCLR
{
	ScreenCapHelper::ScreenCapHelper()
	{
		m_screenRecorder = gcnew ScreenRecorder();
	}

	ScreenCapHelper::ScreenCapHelper(RecordSettingInfo^ recordInfo, ICallbackSIO^ callBack)
	{
		m_screenRecorder = gcnew ScreenRecorder();
		SetRecordSettingInfo(recordInfo);
		SetCallBack(callBack);
	}

	int ScreenCapHelper::add(int a, int b)
	{
		return a + b;
	}

	void ScreenCapHelper::StartRecord()
	{
		m_screenRecorder->StartRecord();
	}

	void ScreenCapHelper::StopRecord()
	{
		m_screenRecorder->StopRecord();
	}

	void ScreenCapHelper::SetRecordSettingInfo(RecordSettingInfo^ recordSettingInfo)
	{
		m_screenRecorder->SetRecordSettingInfo(recordSettingInfo);
	}

	void ScreenCapHelper::SetCallBack(ICallbackSIO^ callBack)
	{
		m_screenRecorder->SetCallBack(callBack);
	}

}