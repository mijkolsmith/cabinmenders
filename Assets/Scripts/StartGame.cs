﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private int levelToLoad;

    public void GameStart()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
