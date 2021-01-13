using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    float timer = 0f;
    Text time;
    private string minutes;
    public string seconds;

    public int secondsPassed;

    public bool playing = true;

    void Update()
    {
        ComponentGetter();
        if (SceneManager.GetActiveScene().name == "Tutorial_v2" && playing == true)
        {
            timer += Time.deltaTime;
        }
        if (SceneManager.GetActiveScene().name == "Level1_v2" && playing == true)
        {
            timer += Time.deltaTime;
        }
        if (SceneManager.GetActiveScene().name == "Level2_v3" && playing == true)
        {
            timer += Time.deltaTime;
        }
        if (SceneManager.GetActiveScene().name == "Level3_v2" && playing == true)
        {
            timer += Time.deltaTime;
        }
        if (SceneManager.GetActiveScene().name == "Level4" && playing == true)
        {
            timer += Time.deltaTime;
        }
        if (SceneManager.GetActiveScene().name == "Level5" && playing == true)
        {
            timer += Time.deltaTime;
        }

    }
    void OnGUI()
    {
        minutes = Mathf.Floor(timer / 60).ToString("00");
        seconds = Mathf.RoundToInt((timer % 60)).ToString("00");
        secondsPassed = Mathf.RoundToInt(timer);
        Debug.Log(secondsPassed);

        if (GameObject.Find("Text") != null && SceneManager.GetActiveScene().name == "Tutorial_v2")
        {
            time.text = minutes + ":" + seconds;
        }
        if (GameObject.Find("Text") != null && SceneManager.GetActiveScene().name == "Level1_v2")
        {
            time.text = minutes + ":" + seconds;
        }
        if (GameObject.Find("Text") != null && SceneManager.GetActiveScene().name == "Level2_v3")
        {
            time.text = minutes + ":" + seconds;
        }
        if (GameObject.Find("Text") != null && SceneManager.GetActiveScene().name == "Level3_v2")
        {
            time.text = minutes + ":" + seconds;
        }
        if (GameObject.Find("Text") != null && SceneManager.GetActiveScene().name == "Level4")
        {
            time.text = minutes + ":" + seconds;
        }
        if (GameObject.Find("Text") != null && SceneManager.GetActiveScene().name == "Level5")
        {
            time.text = minutes + ":" + seconds;
        }

    }

    void ComponentGetter()
    {
        if (GameObject.Find("Text") != null && time == null)
        {
            timer = 0f;
            time = GameObject.Find("Text").GetComponent<Text>();
        }
    }
}
