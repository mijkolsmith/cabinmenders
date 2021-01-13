using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVid : MonoBehaviour
{
    public GameObject Image;
    public GameObject Button;
    public VideoPlayer vp;

    private void Update()
    {
		if (vp.isPlaying == true)
		{
			Image.SetActive(false);
			Button.SetActive(false);
		}

		if (vp.isPlaying == false)
        {
            Image.SetActive(true);
            Button.SetActive(true);
        }
    }
}