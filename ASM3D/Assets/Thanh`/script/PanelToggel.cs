using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToggel : MonoBehaviour
{
    public GameObject panel; 

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePanel();
        }
    }

    
    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

}
