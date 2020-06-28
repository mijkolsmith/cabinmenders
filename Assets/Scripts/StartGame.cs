using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private int level;

    private void Update()
    {
        if (Input.anyKey)
        {
            GameStart();
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene(level);
    }
}
