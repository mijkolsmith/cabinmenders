using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    int count = 0;
    [SerializeField]
    int points = 0;
    private GameObject _gm;
    public GameObject star;

    void Start()
    {
        _gm = GameObject.Find("GameManager(Clone)");
        count = GameObject.FindGameObjectsWithTag("Ceramic").Length + GameObject.FindGameObjectsWithTag("Wood").Length + GameObject.FindGameObjectsWithTag("Cloth").Length;
    }

    void Update()
    {
        if (count == 0)
        {
            _gm.GetComponent<Timer>().playing = false;
            Time.timeScale = 0;
            for (int i = 90; i > int.Parse(_gm.GetComponent<Timer>().seconds); i-=30)
            {
                points++;
            }
            for (int i = -1; i < points-1; i++)
            {
                Instantiate(star, new Vector3(4*i,0,0), Quaternion.identity);
            }
            count--;
        }
        else if (count > 0)
        {
            count = GameObject.FindGameObjectsWithTag("Ceramic").Length + GameObject.FindGameObjectsWithTag("Wood").Length + GameObject.FindGameObjectsWithTag("Cloth").Length;
        }
        if (Input.anyKeyDown && count == -1)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
