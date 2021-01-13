using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private int levelToLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
