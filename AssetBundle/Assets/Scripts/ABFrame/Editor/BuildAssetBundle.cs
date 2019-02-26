
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class BuildAssetBundle
{
    [MenuItem("ABTools/BuildAssetBundles")]
    public static void BuildAllAB()
    {

        //打包AB输出路径
        string strABOutPathDIR = string.Empty;

        //获取"StreamingAssets"数值
        strABOutPathDIR = PathTools.GetABOutPath();

        //判断生成输出目录文件夹
        if(!Directory.Exists(strABOutPathDIR))
        {
            Directory.CreateDirectory(strABOutPathDIR);
        }

        //打包生成
        BuildPipeline.BuildAssetBundles(strABOutPathDIR,BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);

        AssetDatabase.Refresh();
    }
}

