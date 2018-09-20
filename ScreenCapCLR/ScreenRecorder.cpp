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

	// 调用SetProcessDPIAware 启用dpi识别功能 iLogicalScreenWidth = 2560, iPhysicalScreenWidth = 2560, 2560x1600
	// 不用SetProcessDPIAware 启用dpi识别功能 iLogicalScreenWidth = 2560, iPhysicalScreenWidth = 2560, 2560x1600
	// 不用SetProcessDPIAware 禁用dpi识别功能 iLogicalScreenWidth = 1280, iPhysicalScreenWidth = 2560, 1280x800
	// 调用SetProcessDPIAware 禁用dpi识别功能 iLogicalScreenWidth = 2560, iPhysicalScreenWidth = 2560, 2560x1600 界面变形
	// 如果不设置dpiAware，SetSize设置0的时候，只会录制1280x800的大小
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

	//授权信息验证成功后，取得授权的剩余天数。 
	//当有回调通知授权信息更新时，可以再次调用 RDLive_GetAccreditDays 接口得到授权剩余天数。 
	FLOAT fDays = RDLive_GetAccreditDays(eAccreditLocalSave);
	// 视频输出尺寸
	if (!Render_SetSize(iPhysicalScreenWidth, iPhysicalScreenHeight))
	{
		::MessageBoxA(NULL, "RDLiveSDK_ResetAccredit", "", 0);
	}

	FLOAT				fFPS = 25;
	// 开/关鼠标指针图像捕获
	BOOL				bCursorCapture = TRUE;

	// 开/关鼠标指针图像捕获
	Cursor_EnableCapture(bCursorCapture);
	Render_SetFps(fFPS);

	// 屏幕
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

	// 摄像头
	int iCameraCount = Camera_GetCount();
	for (int i = 0; i < iCameraCount; i++)
	{
		_stprintf_s(szMessage, MAX_PATH, _T("Camera = %d, FriendlyName = %s, InternalName = %s\n"),
			i,
			Camera_GetFriendlyName(i),
			Camera_GetInternalName(i));
		OutputDebugString(szMessage);
	}

	// 扬声器(Speaker)
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

	// 麦克风(Microphone)
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
		// 扬声器和麦克风 
		Audio_Enable(eAudCap_Speaker, TRUE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, TRUE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}
	else if (iAudioTestFlag == 2)
	{
		// 仅扬声器 
		Audio_Enable(eAudCap_Speaker, TRUE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, FALSE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}
	else if (iAudioTestFlag == 3)
	{
		// 仅麦克风_扬声器未静音
		Audio_Enable(eAudCap_Speaker, FALSE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, TRUE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}
	else if (iAudioTestFlag == 4)
	{
		// 仅麦克风_扬声器静音
		Audio_Enable(eAudCap_Speaker, FALSE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, TRUE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}
	else if (iAudioTestFlag == 5)
	{
		// 无扬声器和无麦克风
		Audio_Enable(eAudCap_Speaker, FALSE);
		Audio_SetVolume(eAudCap_Speaker, 1.0f);
		Audio_Enable(eAudCap_Microphone, FALSE);
		Audio_SetVolume(eAudCap_Microphone, 1.0f);
	}

	//创建一个场景。得到场景句柄，之后对该场景的操作，都通过句柄来完成。 
	HSCENE hScene = Render_CreateScene();
	//创建一个元件。得到元件句柄。之后对该元件的操作，都通过句柄来完成。 
	HCHIP hChip = NULL;
	if (TRUE)
	{
		// 全屏
		hChip = Scene_CreateChip(hScene, ePinInput_Screen);
		//为元件设置图像来源。这里设置为录制第一个屏幕。0 代表第一个屏幕，1代表第二个屏幕，依次类推 
		//if ( !Chip_Open( hChip, L"0", FALSE, NULL ) ) 
		//{ 
		//	//错误处理
		//	::MessageBoxA(NULL, "Chip_Open","",0);
		//}
		IScreen_SCapParams	sCapParams = { 0 };
		sCapParams.iScreen = -1;
		sCapParams.bUseInitRect = FALSE;
		sCapParams.bOnlyClient = FALSE;
		RECT rect = { 0 };
		rect.left = 50;
		rect.top = 0;
		rect.right = 300; // 距离左边距
		rect.bottom = 500;
		sCapParams.rtInit = rect;
		LPCWSTR szSourceName = Screen_AssembleSource(&sCapParams);
		if (!Chip_Open(hChip, szSourceName, FALSE, NULL))
		{
			//错误处理
			::MessageBoxA(NULL, "Chip_Open", "", 0);
		}
		else
		{
			// Chip_SetRectPercent( hChip, 0.0f, 0.0f, 1.0f, 1.0f, eKeepAspectRatio );
		}
	}
	else if (FALSE)
	{
		// 指定窗口
		hChip = Scene_CreateChip(hScene, ePinInput_Screen);
		IScreen_SCapParams	sCapParams = { 0 };
		sCapParams.hWindow = (HWND)0x00;
		//为元件设置图像来源。这里设置为录制第一个屏幕。0 代表第一个屏幕，1代表第二个屏幕，依次类推 
		if (!Chip_Open(hChip, Screen_AssembleSource(&sCapParams)))
		{
			//错误处理
			::MessageBoxA(NULL, "Chip_Open", "", 0);
		}
		else
		{
			Chip_SetRectPercent(hChip, 0.0f, 0.0f, 1.0f, 1.0f, eKeepAspectRatio);
		}
	}
	else if (TRUE)
	{
		// 指定摄像头
		hChip = Scene_CreateChip(hScene, ePinInput_Camera);
		LPCWSTR szCameraInternalName = Camera_GetInternalName(0);
		if (!Chip_Open(hChip, szCameraInternalName))
		{
			//错误处理
			::MessageBoxA(NULL, "Chip_Open", "", 0);
		}
		else
		{
			Chip_SetRectPercent(hChip, 0.0f, 0.0f, 1.0f, 1.0f, eKeepAspectRatio);
		}
	}

	//设置元件显示。新创建的元件默认是隐藏的，不会绘制，因此要设置为显示。 
	Chip_SetVisible(hChip, TRUE);

	//设置视频编码器为 x264。 
	Encoder_SetCurrent(VE_X264);
	//设置 x264 编码器的 Perset 为 Medium。 
	Encoder_SetPreset(VE_X264, VP_x264_Medium);
	//设置码率为 1000Kbps，模式为“平均码率”。 
	Encoder_SetBitrate(VR_AverageBitrate, 1000, 0, 0);
	//设置录音的参数为 2 声道，22050hz 16bit 采样率，AAC 编码，码率 96Kbps。 
	Encoder_SetAudioParams(2, Aud_Inp_Samp_22050, 16, Aud_Enc_AAC, 96);
	//设置保存文件和直播信息的相关结构。 
	SEncoderSaveFile sFile;
	ZeroMemory(&sFile, sizeof(sFile));

	//设置文件格式为 FLV 
	sFile.eContainer = (EFileContainer)m_recordSettingInfo->GetSaveRecordFileType();
	
	//设置文件保存路径
	pin_ptr<const wchar_t> pStr = PtrToStringChars(m_recordSettingInfo->GetSaveRecordFilePath());
	sFile.szSavePath = pStr;
	//sFile.szSavePath = L"d:\\testrd2.mp4";
	//添加到视频输出列表。 
	if (-1 == Encoder_AddSaveFile(&sFile))
	{
		//失败可能是由于没有获得授权，或者路径格式不正确 
		DWORD dwError = GetLastError();
		::MessageBoxA(NULL, "Encoder_AddSaveFile", "", 0);
	}
	////再设置一个输出，为 RTMP 直播。 
	//sFile.eContainer = Mix_RTMP; 
	////设置类型为 RTMP 直播 
	//sFile.szSavePath = L"rtmp://192.168.0.1/live/abc"; 
	////设置直播的 URL 
	//if ( -1 == Encoder_AddSaveFile( &sFile ) ) 
	//{ 
	//	//失败可能是由于没有获得授权，或者URL格式不正确 
	//	DWORD dwError = GetLastError(); 
	//} 

	//开始录制和直播。 
	if (!Encoder_Start())
	{
		//通常是由于没有设置任何输出才导致返回失败。因为打开文件和连接网络的操作等等都是异步的，如果失败会通过回调函数进行通知。 
		::MessageBoxA(NULL, "Encoder_Start failed....................", "", 0);
	}
	else
	{
		::MessageBoxA(NULL, "Encoder_Start OK", "", 0);
	}
}

void ScreenRecorder::StopRecord()
{
	//停止录制。 
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
