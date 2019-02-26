﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTools
{

    public const string AB_RESOURCES = "AB_Res";


    /// <summary>
    /// 得到AB资源的输入目录
    /// </summary>
    /// <returns></returns>
    public static string GetABResourcesPath()
    {
        return Application.dataPath + "/" + AB_RESOURCES;
    }

    /// <summary>
    /// 获取AB输出路径
    /// </summary>
    public static string GetABOutPath()
    {
        return GetPlatformPath() + "/" + GetPlatformName();
    }

    /// <summary>
    /// 获取平台的路径
    /// </summary>
    /// <returns></returns>
    private static string GetPlatformPath()
    {
        string strReturnPlatformPath = string.Empty;

        switch(Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                strReturnPlatformPath = Application.streamingAssetsPath;
                break;
            case RuntimePlatform.IPhonePlayer:
            case RuntimePlatform.Android:
                strReturnPlatformPath = Application.persistentDataPath;
                break;
            default:
                break;
        }

        return strReturnPlatformPath;
    }

    /// <summary>
    /// 获取平台的名称
    /// </summary>
    /// <returns></returns>
    public static string GetPlatformName()
    {
        string strReturnPlatformName = string.Empty;

        switch(Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                strReturnPlatformName = "Windows";
                break;
            case RuntimePlatform.IPhonePlayer:
                strReturnPlatformName = "Iphone";
                break;
            case RuntimePlatform.Android:
                strReturnPlatformName = "Android";
                break;
            default:
                break;
        }

        return strReturnPlatformName;
    }


    /// <summary>
    /// 获取WWW协议下载（AB包）路径
    /// </summary>
    /// <returns></returns>
    public static string GetWWWPath()
    {
        //返回路径字符串
        string strReturnWWWPath = string.Empty;

        switch(Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                strReturnWWWPath = "file://" + GetABOutPath();
                break;
            case RuntimePlatform.Android:
                strReturnWWWPath = "jar:file://" + GetABOutPath();
                break;
            case RuntimePlatform.IPhonePlayer:
                strReturnWWWPath = GetABOutPath() + "/Raw/";
                break;
            default:
                break;
        }

        return strReturnWWWPath;
    }

}



