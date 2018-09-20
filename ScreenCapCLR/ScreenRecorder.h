#pragma once
#include "RecordInfo.h"

using namespace ScreenCapCLR;

public interface class ICallbackSIO
{
	void TestCallBack(int test);
};

ref class ScreenRecorder
{
public:
	ScreenRecorder();

	void testPrint();

	void StartRecord();

	void StopRecord();

	void SetRecordSettingInfo(RecordSettingInfo^ recordSettingInfo);

	void SetCallBack(ICallbackSIO^ callBack);

	static ICallbackSIO^ callBack;

private:
	RecordSettingInfo ^ m_recordSettingInfo;
};
