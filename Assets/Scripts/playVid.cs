using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class playVid : MonoBehaviour
{
    public GameObject Image;
    public GameObject Button;
    public VideoPlayer vp;

    void Start()
    {
        Image.SetActive(false);
        Button.SetActive(false);
    }

    private void Update()
    {
        if (vp.isPlaying == false)
        {
            Image.SetActive(true);
            Button.SetActive(true);
        }
    }
}
