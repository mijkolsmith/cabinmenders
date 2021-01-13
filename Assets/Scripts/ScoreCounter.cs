using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int count;
    [SerializeField] private int points = 0;
    private GameObject gm;
	[SerializeField] private GameObject star;
	[SerializeField] private GameObject noStar;

    void Start()
    {
		gm = GameManager.instance.gameObject;
        count = GameObject.FindGameObjectsWithTag("Ceramic").Length + GameObject.FindGameObjectsWithTag("Wood").Length + GameObject.FindGameObjectsWithTag("Cloth").Length;
    }

    void Update()
	{
		if (count > 0)
		{//update the count
			count = GameObject.FindGameObjectsWithTag("Ceramic").Length + GameObject.FindGameObjectsWithTag("Wood").Length + GameObject.FindGameObjectsWithTag("Cloth").Length;
		}
		else if (count == 0)
        {//if all objects have been fixed display the score
            gm.GetComponent<ScoreTimer>().playing = false;
            for (int i = 90; i > gm.GetComponent<ScoreTimer>().secondsPassed; i -= 30)
            {
                points++;
            }
            for (int i = -1; i < 2; i++)
            {
                Instantiate(noStar, new Vector3(4 * i, 0, 0), Quaternion.identity);
            }
            for (int i = -1; i < points-1; i++)
            {
                Instantiate(star, new Vector3(4 * i, 0, 0), Quaternion.identity);
            }
            
            count--;
            Time.timeScale = 0;
        }
        if (Input.anyKeyDown && count == -1)
        {//go to next level
            Time.timeScale = 1;
			gm.GetComponent<ScoreTimer>().playing = true;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}