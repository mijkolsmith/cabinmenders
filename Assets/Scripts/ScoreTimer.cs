using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour
{
    float timer = 0f;
    Text time;
    private string minutes;
    public string seconds;

    public int secondsPassed;

    public bool playing = true;

    void Update()
    {
		if (time == null)
		{
			ComponentGetter();
		}
        
        if (playing == true &&
		   (SceneManager.GetActiveScene().name == "Tutorial_v2" || 
			SceneManager.GetActiveScene().name == "Level1_v2" || 
			SceneManager.GetActiveScene().name == "Level2_v3" ||
			SceneManager.GetActiveScene().name == "Level3_v2" ||
			SceneManager.GetActiveScene().name == "Level4" ||
			SceneManager.GetActiveScene().name == "Level5"))
        {
            timer += Time.deltaTime;
        }
    }

    void OnGUI()
    {
        minutes = Mathf.Floor(timer / 60).ToString("00");
        seconds = Mathf.RoundToInt((timer % 60)).ToString("00");
        secondsPassed = Mathf.RoundToInt(timer);

        if (GameObject.Find("Text") != null &&
			(SceneManager.GetActiveScene().name == "Tutorial_v2" ||
			SceneManager.GetActiveScene().name == "Level1_v2" ||
			SceneManager.GetActiveScene().name == "Level2_v3" ||
			SceneManager.GetActiveScene().name == "Level3_v2" ||
			SceneManager.GetActiveScene().name == "Level4" ||
			SceneManager.GetActiveScene().name == "Level5"))
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