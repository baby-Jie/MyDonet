#pragma once

//#include "targetver.h"
#define _CRT_SECURE_NO_WARNINGS
#include <SDKDDKVer.h>

#define WIN32_LEAN_AND_MEAN             //  从 Windows 头文件中排除极少使用的信息
// Windows 头文件:
#include <windows.h>

// C 运行时头文件
#include <stdlib.h>
#include <malloc.h>
#include <memory.h>
#include <tchar.h>

#include "./Include/RDLiveSDK.h"
#pragma comment ( lib, ".\\Lib\\RDLiveSDK.lib " )


//保存视频文件的格式
public enum	class EFileContainer_Net
{
	Mix_FLV,
	Mix_MP4,
	Mix_AVI,

	Mix_RTMP,
	Mix_RdCloud,

	Vid_264,	//H264裸流，不封装，无音频
	Aud_ONLY,	//AAC/MP3文件，无视频

	File_Container_TypeCount
};

public enum class IRender_ENotify_Net
	{
		eNotify_None,
		//预览画面中的添加场景按钮被点击。得到此通知，上层如果不调用添加场景的接口，就不会添加场景。
		eNotify_SceneAdding,	//NULL							//已有场景的数量
		//添加了一个场景。
		eNotify_SceneAdded,		//添加的场景					//是否影响到了预览布局(0=无影响, 其它值表示布局改变)
		//预览画面中的删除场景按钮被点击。得到此通知，上层如果不调用删除场景的接口，就不会删除场景。
		eNotify_SceneDeleting,	//将要删除的场景
		//删除了一个场景。
		eNotify_SceneDeleted,	//删除的场景					//是否影响到了预览布局(0=无影响, 其它值表示布局改变)
		//切换了场景，选中了一个场景作为当前场景。
		eNotify_SceneSwitched,	//当前选中的场景，如果为 NULL，则当前没有任何场景被选中
		//场景的名字发生了改变
		eNotify_SceneNamed,		//名字发生改变的场景
		//拖动了后台场景预览区域的滚动条，或者滚动条的值范围发生了改变。
		eNotify_SceneScroll,	//后台场景区域当前第一个场景	//LOWORD=滚动条的最大值，HIWORD=滚动条的当前值

		//在预览画面上按下了鼠标右键，上层酌情处理，例如弹出右键菜单。
		eNotify_RBDownCScene,	//当前场景						//鼠标所在的元件的Index，-1表示没在任何元件上。
		eNotify_RBDownBScene,	//鼠标所在的场景，NULL 表示没在任何场景上。
		eNotify_RBUpCScene,
		eNotify_RBUpBScene,

		//对元件进行的操作。上层可以在得到通知时更新界面上的相关状态。
		eNotify_ChipAdding,		//将要添加元件的场景			//场景中已有元件的数量
		eNotify_ChipAdded,		//添加元件的场景				//添加的元件的Index
		eNotify_ChipDeleting,	//将要删除元件的场景			//将要删除的元件的Index
		eNotify_ChipDeleted,	//删除元件的场景				//被删除的元件的Index
		//场景中的元件位置或大小正在被用户改变(鼠标操作)。
		eNotify_ChipPosing,		//当前场景						//被操作的元件的Index
		//场景中的元件位置或大小被用户改变完成(用户结束了操作)。
		eNotify_ChipPosed,		//当前场景						//被操作的元件的Index
		//场景中的元件正在被用户旋转(鼠标操作)。
		eNotify_ChipRotating,	//当前场景						//被操作的元件的Index
		//场景中的元件被用户旋转完成(用户结束了操作)。
		eNotify_ChipRotated,	//当前场景						//被操作的元件的Index
		//切换了场景中当前选中的元件
		eNotify_ChipSwitched,	//元件所属的场景				//低16位，SHORT=当前选中的Index，高16位，SHORT=上次选中的Index
		//场景中的元件的顺序发生了改变。
		eNotify_ChipIndexChg,	//元件所属的场景				//低16位，SHORT=原来的Index，高16位，SHORT=被插入到的Index
		//元件的状态发生改变。
		eNotify_ChipStatus,		//元件所属的场景				//状态发生改变的元件的Index
		//元件的可见状态发生改变
		eNotify_ChipVisible,	//元件所属的场景				//发生改变的元件的Index
		//元件的位置、大小、角度锁定状态发生改变
		eNotify_ChipViewLock,	//元件所属的场景				//发生改变的元件的Index
		//元件的源的分辨率发生改变。
		eNotify_ChipSourceSize,	//元件所属的场景				//源分辨率发生改变的元件的Index

		//其它的通知
		eNotify_CameraDevChanged,//NULL，						//当前摄像头的数量
		eNotify_GameListChanged, //NULL,						//当前的游戏数量
		eNotify_AudioDevChanged,
		eNotify_AudioImmVolume,

		eNotify_Count
	};