using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject uipanel;
    
    [SerializeField]
    private GameObject uiparent;

    // Start is called before the first frame update
    void Start()
    {
        uiparent.transform.rotation = Quaternion.identity;
        uipanel.transform.parent = uiparent.transform;
    }

    public void OnClick()
    {
        if (uipanel.transform.parent == null)
        {
            uipanel.transform.parent = uiparent.transform;
        }
        else
        {
            uipanel.transform.parent = null;
        }
    }
}
