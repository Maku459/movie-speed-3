using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButtonSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var g = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
        if (OVRInput.GetDown(OVRInput.Button.One)){
            g.playbackSpeed += 0.05f;
        } else if(OVRInput.GetDown(OVRInput.Button.Two)){
            g.playbackSpeed -= 0.05f;
        }
    }
}
