using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class speedUp : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
 
    // Update is called once per frame
    void Update()
    {
    }
    
    public void OnClick()
    {
        var g = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        g.playbackSpeed += 0.2f;
    }
}