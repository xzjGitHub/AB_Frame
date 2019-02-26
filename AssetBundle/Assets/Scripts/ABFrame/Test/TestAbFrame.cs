using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

public class TestAbFrame: MonoBehaviour
{

    private string m_sceneName= "scenes_1";

    private string m_abName= "scenes_1/prefab.ab";

    private string m_assetName= "Cube.prefab";

    private void Awake()
    {
        StartCoroutine(ABManifestLoader.Instance.LoadManifestFile());
    }

    private void Start()
    {
        StartCoroutine(AssetBundleMgr.Instance.LoadAssetBundle(m_sceneName,m_abName,LoadCompleteCallBack));
    }


    private void LoadCompleteCallBack(string abName)
    {
        GameObject temp = AssetBundleMgr.Instance.LoadAsset(m_sceneName,m_abName,m_assetName,false) as GameObject;
        GameObject obj = GameObject.Instantiate(temp);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
           
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            AssetBundleMgr.Instance.DisposeAllAsset(m_sceneName);
        }
    }
}

