using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AssetBundleMgr
{

    private static AssetBundleMgr m_instance;
    public static AssetBundleMgr Instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = new AssetBundleMgr();
            }
            return m_instance;
        }
    }

    private Dictionary<string,MutilABMgr> m_allScenes;

    //   private AssetBundleManifest m_mainfest;

    private AssetBundleMgr()
    {
        m_allScenes = new Dictionary<string,MutilABMgr>();
    }


    /// <summary>
    /// 加载指定场景中的ab包
    /// </summary>
    /// <param name="sceneName">场景名</param>
    /// <param name="abName">ab包名</param>
    /// <param name="loadComplete">加载完成回调</param>
    /// <returns></returns>
    public IEnumerator LoadAssetBundle(string sceneName,string abName,LoadComplete loadComplete)
    {
        while(!ABManifestLoader.Instance.IsLoadFnish)
        {
            yield return null;
        }
        //   m_mainfest = ABManifestLoader.Instance.GetAssetBundleManifest();
        if(!m_allScenes.ContainsKey(sceneName))
        {
            MutilABMgr temp = new MutilABMgr(sceneName,abName,loadComplete);
            m_allScenes.Add(sceneName,temp);
        }
        MutilABMgr mutilABMgr = m_allScenes[sceneName];
        yield return mutilABMgr.LoadAssetBundle(abName);
    }

    /// <summary>
    /// 加载指定场景中指定包中的指定资源
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="abName"></param>
    /// <param name="assetName"></param>
    /// <param name="isCache"></param>
    /// <returns></returns>

    public UnityEngine.Object LoadAsset(string sceneName,string abName,string assetName,bool isCache)
    {
        if(m_allScenes.ContainsKey(sceneName))
        {
            MutilABMgr mutilABMgr = m_allScenes[sceneName];
            return mutilABMgr.LoadAsset(abName,assetName,isCache);
        }
        else
        {
            Debug.LogError("加载资源出错,不存在sceneName: " + sceneName);
        }
        return null;
    }

    /// <summary>
    /// 释放一个场景中的所有资源
    /// </summary>
    /// <param name="sceneName"></param>
    public void DisposeAllAsset(string sceneName)
    {
        if(m_allScenes.ContainsKey(sceneName))
        {
            m_allScenes[sceneName].DisposeAllAsset();
        }
        else
        {
            Debug.LogError("加载资源出错,不存在sceneName: " + sceneName);
        }
    }
}

