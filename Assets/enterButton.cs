using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class enterButton : MonoBehaviour
{
    public Text firstText;
    public Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        var g = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        firstText.text = g.playbackSpeed.ToString("F2");
    }

    // Update is called once per frame
    public void OnClick()
    {
        var g = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        resultText.text = g.playbackSpeed.ToString("F2");
        firstText.color = new Color(1.0f,1.0f,1.0f,1.0f);
    }
}
