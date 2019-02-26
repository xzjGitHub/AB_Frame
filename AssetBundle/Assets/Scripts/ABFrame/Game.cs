﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Game: MonoBehaviour
{

    public static Game Instance;

    private void Awake()
    {
        Instance = this;

        StartCoroutine(ABManifestLoader.Instance.LoadManifestFile());
    }

}

