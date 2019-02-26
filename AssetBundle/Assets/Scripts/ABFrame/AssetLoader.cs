using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public class AssetLoader:IDisposable
{

    private AssetBundle m_currentAssetBundle;

    private Hashtable m_hash;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="ab">给定www加载的ab</param>
    public AssetLoader(AssetBundle ab)
    {
        if (ab != null)
        {
            m_currentAssetBundle = ab;
            m_hash = new Hashtable();
        }
        else
        {
            Debug.LogError("AssetLoader 构造函数 ab is null");
        }
    }

    /// <summary>
    /// 加载指定的资源
    /// </summary>
    /// <param name="assetName">资源名称</param>
    /// <param name="isCache">是否需要缓存</param>
    /// <returns></returns>
    public UnityEngine.Object LoadAsset(string assetName,bool isCache=false)
    {
        return LoadResource<UnityEngine.Object>(assetName,isCache);
    }

    /// <summary>
    /// 加载资源
    /// </summary>
    /// <param name="assetName">资源名称</param>
    /// <param name="isCache">是否需要缓存</param>
    /// <returns></returns>
    private T LoadResource<T>(string assetName,bool isCache = false) where T : UnityEngine.Object
    {
        //先判断是否已经缓存
        if (m_hash.Contains(assetName))
        {
            return m_hash[assetName] as T;
        }

        T temp = m_currentAssetBundle.LoadAsset<T>(assetName);
        if (temp!=null && isCache)
        {
            m_hash[assetName] = temp;
        }
        else if (temp == null)
        {
            Debug.LogError(GetType() + "/ 获取资源为空，资源名： "+assetName);
        }
        return temp;
    }

    /// <summary>
    /// 卸载指定资源
    /// </summary>
    /// <param name="asset"></param>
    /// <returns></returns>
    public bool UnLoadAsset(UnityEngine.Object asset)
    {
        if (asset != null)
        {
            Resources.UnloadAsset(asset);
            return true;
        }
        else
        {
            Debug.LogError(GetType() + "要卸载得资源为空");
            return false;
        }
    }


    /// <summary>
    /// 释放当前镜像资源 还要释放内存资源
    /// </summary>
    public void DisposeAll()
    {
        m_currentAssetBundle.Unload(true);
    }

    /// <summary>
    /// 释放内存镜像资源
    /// </summary>
    public void Dispose()
    {
        m_currentAssetBundle.Unload(false);
    }

    /// <summary>
    /// 查询包含得所有资源名称
    /// </summary>
    /// <returns></returns>
    public string[] RetiveAllAssetName()
    {
        return m_currentAssetBundle.GetAllAssetNames();
    }
}

