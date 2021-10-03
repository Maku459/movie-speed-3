using UnityEngine;
using UnityEngine.UI;
 
public class testDebug : MonoBehaviour
{
    bool inMenu;
 
    void Start ()
    {
        DebugUIBuilder.instance.AddLabel("Debug Start", DebugUIBuilder.DEBUG_PANE_CENTER);
        DebugUIBuilder.instance.AddLabel("Debug Log", DebugUIBuilder.DEBUG_PANE_LEFT);
        DebugUIBuilder.instance.Show();
        inMenu = true;
    }
 
    void Update()
    {
        
    }
}