#pragma once
#include "stdafx.h"
using namespace System;

namespace ScreenCapCLR
{
	public ref class RecordSettingInfo
	{
	public:
		RecordSettingInfo();

		void SetSaveRecordFilePath(System::String^ filePath);
		System::String^ GetSaveRecordFilePath();

		void SetSaveRecordFileType(EFileContainer_Net fileType);

		EFileContainer_Net GetSaveRecordFileType();

	private:
		System::String^ m_saveRecordFilePath = gcnew System::String("d:\\testrecord.mp4");
		EFileContainer_Net m_saveRecordFileType = EFileContainer_Net::Mix_MP4;
	};
}


