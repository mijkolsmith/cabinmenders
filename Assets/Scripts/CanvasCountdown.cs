using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasCountdown : MonoBehaviour
{
    public GameObject[] _players;

    [SerializeField]
    private GameObject _errorText;

    [SerializeField]
    private Text text;

    float timer = 5;

    private AudioSource _audioSource;

    private void Start()
    {
        _errorText.SetActive(false);

        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(_players[0].GetComponent<CharacterSelection>()._number == _players[1].GetComponent<CharacterSelection>()._number)
        {
            _errorText.SetActive(true);
        }
        else
        {
            _errorText.SetActive(false);
        }

        if(_players[0].GetComponent<CharacterSelection>().selected && _players[1].GetComponent<CharacterSelection>().selected && !_errorText.activeInHierarchy)
        {
            timer -= Time.deltaTime;
        } else
        {
            timer = 5;
        }

        if (timer <= 0)
            SceneManager.LoadScene(2);
    }

    private void OnGUI()
    {
        string seconds = Mathf.RoundToInt((timer % 60)).ToString();

        text.text = seconds;
    }
}
