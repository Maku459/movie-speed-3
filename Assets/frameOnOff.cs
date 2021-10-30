using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class frameOnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject subcam;
    
    [SerializeField]
    private GameObject frame;
    
    [SerializeField]
    private GameObject dummyframe;

    [SerializeField]
    private GameObject rawimg;
    
    // Start is called before the first frame update
    void Start()
    {
        subcam.SetActive(false);
        frame.SetActive(false);
        dummyframe.SetActive(false);
        rawimg.SetActive(false);
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (frame.activeSelf)
        {
            subcam.SetActive(false);
            frame.SetActive(false);
            dummyframe.SetActive(false);
            rawimg.SetActive(false);
        }
        else
        {
            subcam.SetActive(true);
            frame.SetActive(true);
            dummyframe.SetActive(true);
            rawimg.SetActive(true);
        }
    }
}
