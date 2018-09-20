#include "stdafx.h"
#include "ScreenRecorder.h"
#include <iostream>
//#include <windows.h>  
#include <vcclr.h>  
//#using <System.dll>

using namespace std;

VOID WINAPI RenderNotifyCB(IRender_ENotify eNotify, HSCENE hScene, INT iValue, LPVOID pCbParam);
VOID WINAPI EncoderNotifyCB(IEncoder_ENotify eNotify, DWORD dwValue, DWORD_PTR ptrValue, LPVOID pCbParam);

ScreenRecorder::ScreenRecorder()
{

}

void ScreenRecorder::testPrint()
{
	cout << "hello this is c++" << endl;
}

void ScreenRecorder::StartRecord()
{
	TCHAR szMessage[MAX_PATH];

	// ����SetProcessDPIAware ����dpiʶ���� iLogicalScreenWidth = 2560, iPhysicalScreenWidth = 2560, 2560x1600
	// ����SetProcessDPIAware ����dpiʶ���� iLogicalScreenWidth = 2560, iPhysicalScreenWidth = 2560, 2560x1600
	// ����SetProcessDPIAware ����dpiʶ���� iLogicalScreenWidth = 1280, iPhysicalScreenWidth = 2560, 1280x800
	// ����SetProcessDPIAware ����dpiʶ���� iLogicalScreenWidth = 2560, iPhysicalScreenWidth = 2560, 2560x1600 �������
	// ���������dpiAware��SetSize����0��ʱ��ֻ��¼��1280x800�Ĵ�С
	SetProcessDPIAware();

	HDC screen = GetDC(NULL);
	int iLogicalScreenWidth = GetDeviceCaps(screen, HORZRES);
	int iPhysicalScreenWidth = GetDeviceCaps(screen, DESKTOPHORZRES);
	int iLogicalScreenHeight = GetDeviceCaps(screen, VERTRES);
	int iPhysicalScreenHeight = GetDeviceCaps(screen, DESKTOPVERTRES);
	ReleaseDC(NULL, screen);
	_stprintf_s(szMessage, MAX_PATH, _T("iLogicalScreenWidth = %d, iPhysicalScreenWidth = %d\n"), iLogicalScreenWidth, iPhysicalScreenWidth);
	OutputDebugString(szMessage);

	if (!RDLive_Init(L"17RD", L"RDLiveSdkDemo", RenderNotifyCB, EncoderNotifyCB, NULL))
	{
		::MessageBoxA(NULL, "Init Fail!", "RDLiveSDK", 0);
	}

	if (!RDLive_ResetAccredit("d3200cc987431827|RDLiveSDK_Demo.exe",
		"77a9eeea008524e8bdf10e18409cbdb3sULczML4CjomZFtst04v/HLUrHqWT72Mmkz7WhUEmpjXMH7/UWz5oGMwUGQPbYX+MKSpM01lSGQ/qNzCkFFyKXSwxrKIViR4iZ7ZxOuB6n80wDeCV7jHJSEN1+DqlCLm3dJWQF3CFLMOj2YJxwI/YDY9h3SjCsWFz9j/71RCHH0FWpr13vMRM6a1uRCnke2Tyly/V4S4E7BE1tR6WDcxNQTeX9w399l/EpNb8LvBNNUz6shNmM627BGBfTbPG2vj+grPaxv1rFcVRqNkT45Jrjvjp3PV8L6Py7fCUvK5PJ0Pb/olb9q/M2Yom+AZkSlE0FDcSKb0MG+QCE9f1MYacjFoU31o7cZb5ZQZ++7lMqXMDvTi9LyTYR+0lDKKwFC8EJ43/upbIuhawyXQ2w4u7Zvv9IUXqhamlTUirPmuV4lSVypdzCT+gPdEjq9krLLjRajAMutBwefKiHdrp/h65BxTErT94rH7OAU6bCmbX/o="))
	{
		::MessageBoxA(NULL, "RDLiveSDK_ResetAccredit", "", 0);
	}

	//��Ȩ��Ϣ��֤�ɹ���ȡ����Ȩ��ʣ�������� 
	//���лص�֪ͨ��Ȩ��Ϣ����ʱ�������ٴε��� RDLive_GetAccreditDays �ӿڵõ���Ȩʣ�������� 
	FLOAT fDays = RDLive_GetAccreditDays(eAccreditLocalSave);
	// ��Ƶ����ߴ�
	if (!Render_SetSize(iPhysicalScreenWidth, iPhysicalScreenHeight))
	{
		::MessageBoxA(NULL, "RDLiveSDK_ResetAccredit", "", 0);
	}

	FLOAT				fFPS = 25;
	// ��/�����ָ��ͼ�񲶻�
	BOOL				bCursorCapture = TRUE;

	// ��/�����ָ��ͼ�񲶻�
	Cursor_EnableCapture(bCursorCapture);
	Render_SetFps(fFPS);

	// ��Ļ
	MONITORINFOEXW	monit;
	int iScreenCount = Screen_GetCount();
	for (int i = 0; i < iScreenCount; ++i)
	{
		Screen_GetInfo(i, &monit);
		_stprintf_s(szMessage, MAX_PATH, _T("Screen = %d, Name = %s, Rect = %d,%d,%d,%d\n"),
			i,
			monit.szDevice,
			monit.rcMonitor.left,
			monit.rcMonitor.top,
			monit.rcMonitor.right,
			monit.rcMonitor.bottom);
		OutputDebugString(szMessage);
	}

	// ����ͷ
	int iCameraCount = Camera_GetCount();
	for (int i = 0; i < iCameraCount; i++)
	{
		_stprintf_s(szMessage, MAX_PATH, _T("Camera = %d, FriendlyName = %s, InternalName = %s\n"),
			i,
			Camera_GetFriendlyName(i),
			Camera_GetInternalName(i));
		OutputDebugString(szMessage);
	}

	// ������(Speaker)
	LPCWSTR szCurrentSpeakerDeviceId = Audio_GetCurrent(eAudCap_Speaker);
	FLOAT fSpeakerVolume = Audio_GetVolume(eAudCap_Speaker);
	BOOL bSpeakerEnable = Audio_IsEnabled(eAudCap_Speaker);
	int	iSpeakerCount = Audio_GetDevCount(eAudCap_Speaker);

	_stprintf_s(szMessage, MAX_PATH, _T("SpeakerCount = %d, CurrentSpeakerDeviceId = %s, SpeakerVolume = %f, SpeakerEnable = %d\n"),
		iSpeakerCount,
		szCurrentSpeakerDeviceId,
		fSpeakerVolume,
		bSpeakerEnable);
	OutputDebugString(szMessage);

	for (int i = 0; i < iSpeakerCount; i++)
	{
		LPCWSTR szSpeakerDeviceId = Audio_GetDevId(eAudCap_Speaker, i);
		LPCWSTR szSpeakerDeviceName = Audio_GetDevName(eAudCap_Speaker, i);

		_stprintf_s(szMessage, MAX_PATH, _T("Speaker = %d, DeviceId = %s, DeviceName = %s\n"),
			i,
			szSpeakerDeviceId,
			szSpeakerDeviceName);
		OutputDebugString(szMessage);
	}

	// ��˷�(Microphone)
	LPCWSTR szCurrentMicrophoneDeviceId = Audio_GetCurrent(eAudCap_Microphone);
	FLOAT fMicrophoneVolume = Audio_GetVolume(eAudCap_Microphone);
	BOOL bMicrophoneEnable = Audio_IsEnabled(eAudCap_Microphone);
	int	iMicrophoneCount = Audio_GetDevCount(eAudCap_Microphone);

	_stprintf_s(szMessage, MAX_PATH, _T("MicrophoneCount = %d, CurrentMicrophoneDeviceId = %s, MicrophoneVolume = %f, MicrophoneEnable = %d\n"),
		iMicrophoneCount,
		szCurrentMicrophoneDeviceId,
		fMicrophoneVolume,
		bMicrophoneEnable);
	OutputDebugString(szMessage);

	for (int i = 0; i < iMicrophoneCount; i++)
	{
		LPCWSTR szMicrophoneDeviceId = Audio_GetDevId(eAudCap_Microphone, i);
		LPCWSTR szMicrophoneDeviceName = Audio_GetDevName(eAudCap_Microphone, i);

		_stprintf_s(szMessage, MAX_PATH, _T("Microphone = %d, DeviceId = %s, DeviceName = %s\n"),
			i,
			szMicrophoneDeviceId,
			szMicrophoneDeviceName);
		OutputDebugString(szMessage);
	}

	int iAudioTestFlag = 4;
	if (iAudioTestFlag == 1)
	{
		// ����������˷� 
		Audio_Enable(eAudCap_Speaker, TRUE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, TRUE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}
	else if (iAudioTestFlag == 2)
	{
		// �������� 
		Audio_Enable(eAudCap_Speaker, TRUE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, FALSE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}
	else if (iAudioTestFlag == 3)
	{
		// ����˷�_������δ����
		Audio_Enable(eAudCap_Speaker, FALSE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, TRUE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}
	else if (iAudioTestFlag == 4)
	{
		// ����˷�_����������
		Audio_Enable(eAudCap_Speaker, FALSE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, TRUE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}
	else if (iAudioTestFlag == 5)
	{
		// ��������������˷�
		Audio_Enable(eAudCap_Speaker, FALSE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, FALSE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}

	//����һ���������õ����������֮��Ըó����Ĳ�������ͨ���������ɡ� 
	HSCENE hScene = Render_CreateScene();
	//����һ��Ԫ�����õ�Ԫ�������֮��Ը�Ԫ���Ĳ�������ͨ���������ɡ� 
	HCHIP hChip = NULL;
	if (TRUE)
	{
		// ȫ��
		hChip = Scene_CreateChip(hScene, ePinInput_Screen);
		//ΪԪ������ͼ����Դ����������Ϊ¼�Ƶ�һ����Ļ��0 �����һ����Ļ��1����ڶ�����Ļ���������� 
		//if ( !Chip_Open( hChip, L"0", FALSE, NULL ) ) 
		//{ 
		//	//������
		//	::MessageBoxA(NULL, "Chip_Open","",0);
		//}
		IScreen_SCapParams	sCapParams = { 0 };
		sCapParams.iScreen = -1;
		sCapParams.bUseInitRect = FALSE;
		sCapParams.bOnlyClient = FALSE;
		RECT rect = { 0 };
		rect.left = 50;
		rect.top = 0;
		rect.right = 300; // ������߾�
		rect.bottom = 500;
		sCapParams.rtInit = rect;
		LPCWSTR szSourceName = Screen_AssembleSource(&sCapParams);
		if (!Chip_Open(hChip, szSourceName, FALSE, NULL))
		{
			//������
			::MessageBoxA(NULL, "Chip_Open", "", 0);
		}
		else
		{
			// Chip_SetRectPercent( hChip, 0.0f, 0.0f, 1.0f, 1.0f, eKeepAspectRatio );
		}
	}
	else if (FALSE)
	{
		// ָ������
		hChip = Scene_CreateChip(hScene, ePinInput_Screen);
		IScreen_SCapParams	sCapParams = { 0 };
		sCapParams.hWindow = (HWND)0x00;
		//ΪԪ������ͼ����Դ����������Ϊ¼�Ƶ�һ����Ļ��0 �����һ����Ļ��1����ڶ�����Ļ���������� 
		if (!Chip_Open(hChip, Screen_AssembleSource(&sCapParams)))
		{
			//������
			::MessageBoxA(NULL, "Chip_Open", "", 0);
		}
		else
		{
			Chip_SetRectPercent(hChip, 0.0f, 0.0f, 1.0f, 1.0f, eKeepAspectRatio);
		}
	}
	else if (TRUE)
	{
		// ָ������ͷ
		hChip = Scene_CreateChip(hScene, ePinInput_Camera);
		LPCWSTR szCameraInternalName = Camera_GetInternalName(0);
		if (!Chip_Open(hChip, szCameraInternalName))
		{
			//������
			::MessageBoxA(NULL, "Chip_Open", "", 0);
		}
		else
		{
			Chip_SetRectPercent(hChip, 0.0f, 0.0f, 1.0f, 1.0f, eKeepAspectRatio);
		}
	}

	//����Ԫ����ʾ���´�����Ԫ��Ĭ�������صģ�������ƣ����Ҫ����Ϊ��ʾ�� 
	Chip_SetVisible(hChip, TRUE);

	//������Ƶ������Ϊ x264�� 
	Encoder_SetCurrent(VE_X264);
	//���� x264 �������� Perset Ϊ Medium�� 
	Encoder_SetPreset(VE_X264, VP_x264_Medium);
	//��������Ϊ 1000Kbps��ģʽΪ��ƽ�����ʡ��� 
	Encoder_SetBitrate(VR_AverageBitrate, 1000, 0, 0);
	//����¼���Ĳ���Ϊ 2 ������22050hz 16bit �����ʣ�AAC ���룬���� 96Kbps�� 
	Encoder_SetAudioParams(2, Aud_Inp_Samp_22050, 16, Aud_Enc_AAC, 96);
	//���ñ����ļ���ֱ����Ϣ����ؽṹ�� 
	SEncoderSaveFile sFile;
	ZeroMemory(&sFile, sizeof(sFile));

	//�����ļ���ʽΪ FLV 
	sFile.eContainer = (EFileContainer)m_recordSettingInfo->GetSaveRecordFileType();
	
	//�����ļ�����·��
	pin_ptr<const wchar_t> pStr = PtrToStringChars(m_recordSettingInfo->GetSaveRecordFilePath());
	sFile.szSavePath = pStr;
	//sFile.szSavePath = L"d:\\testrd2.mp4";
	//��ӵ���Ƶ����б� 
	if (-1 == Encoder_AddSaveFile(&sFile))
	{
		//ʧ�ܿ���������û�л����Ȩ������·����ʽ����ȷ 
		DWORD dwError = GetLastError();
		::MessageBoxA(NULL, "Encoder_AddSaveFile", "", 0);
	}
	////������һ�������Ϊ RTMP ֱ���� 
	//sFile.eContainer = Mix_RTMP; 
	////��������Ϊ RTMP ֱ�� 
	//sFile.szSavePath = L"rtmp://192.168.0.1/live/abc"; 
	////����ֱ���� URL 
	//if ( -1 == Encoder_AddSaveFile( &sFile ) ) 
	//{ 
	//	//ʧ�ܿ���������û�л����Ȩ������URL��ʽ����ȷ 
	//	DWORD dwError = GetLastError(); 
	//} 

	//��ʼ¼�ƺ�ֱ���� 
	if (!Encoder_Start())
	{
		//ͨ��������û�������κ�����ŵ��·���ʧ�ܡ���Ϊ���ļ�����������Ĳ����ȵȶ����첽�ģ����ʧ�ܻ�ͨ���ص���������֪ͨ�� 
		::MessageBoxA(NULL, "Encoder_Start failed....................", "", 0);
	}
	else
	{
		::MessageBoxA(NULL, "Encoder_Start OK", "", 0);
	}
}

void ScreenRecorder::StopRecord()
{
	//ֹͣ¼�ơ� 
	if (!Encoder_End())
	{
		::MessageBoxA(NULL, "Encoder_End failed........................", "", 0);
	}
	else
	{
		::MessageBoxA(NULL, "Encoder_End OK", "", 0);
	}
}

void ScreenRecorder::SetRecordSettingInfo(RecordSettingInfo^ recordSettingInfo)
{
	this->m_recordSettingInfo = recordSettingInfo;
}

void ScreenRecorder::SetCallBack(ICallbackSIO^ callBack)
{
	ScreenRecorder::callBack = callBack;
}

VOID WINAPI RenderNotifyCB(IRender_ENotify eNotify, HSCENE hScene, INT iValue, LPVOID pCbParam)
{
	//IRender_ENotify_Donet donet = (int)eNotify;
	ScreenRecorder::callBack->TestCallBack(123);
}

VOID WINAPI EncoderNotifyCB(IEncoder_ENotify eNotify, DWORD dwValue, DWORD_PTR ptrValue, LPVOID pCbParam)
{

}
