using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameOnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject frame;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (frame.activeSelf)
        {
            frame.SetActive(false);
        }
        else
        {
            frame.SetActive(true);
        }
    }
}
