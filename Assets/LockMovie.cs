using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMovie : MonoBehaviour
{
    [SerializeField] private GameObject videoplayer;
    
    [SerializeField]
    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnClick()
    {
        if (videoplayer.transform.parent == null)
        {
            videoplayer.transform.parent = parent.transform;
        }
        else
        {
            videoplayer.transform.parent = null;
        }
    }
}
