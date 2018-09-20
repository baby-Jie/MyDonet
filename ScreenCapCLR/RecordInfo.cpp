#include "RecordInfo.h"

namespace ScreenCapCLR
{

	RecordSettingInfo::RecordSettingInfo()
	{
	}

	void RecordSettingInfo::SetSaveRecordFilePath(System::String^ filePath)
	{
		m_saveRecordFilePath = filePath;
	}

	System::String^ RecordSettingInfo::GetSaveRecordFilePath()
	{
		return m_saveRecordFilePath;
	}

	void RecordSettingInfo::SetSaveRecordFileType(EFileContainer_Net fileType)
	{
		m_saveRecordFileType = fileType;
	}

	EFileContainer_Net RecordSettingInfo::GetSaveRecordFileType()
	{
		return m_saveRecordFileType;
	}

}

