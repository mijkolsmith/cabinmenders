using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;

    private void Start()
    {
        _pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseMenu.activeInHierarchy)
            {
                _pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else if(!_pauseMenu.activeInHierarchy)
            {
                _pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
