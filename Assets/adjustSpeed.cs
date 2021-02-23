using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class adjustSpeed : MonoBehaviour
{
 
    public Slider speedSlider;

    float maxSpeed = 2f;
    public float nowSpeed = 1f;
 
    // Use this for initialization
    void Start()
    {
 
        speedSlider = GetComponent<Slider>();
 
 
        //スライダーの最大値の設定
        speedSlider.maxValue = maxSpeed;
 
        //スライダーの現在値の設定
        speedSlider.value = nowSpeed;
 
        
    }
 
    // Update is called once per frame
    void Update()
    {
    }
    
    public void Adjust()
    {
        var g = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        g.playbackSpeed = speedSlider.value;
 
    }
}