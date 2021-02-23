using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class enterButton : MonoBehaviour
{
    
    public Text targetText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClick()
    {
        var g = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        targetText.text = g.playbackSpeed.ToString("F1");
    }
}
