using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFix : MonoBehaviour
{
    private int i_width = 0;
    private int i_height = 0;

    void Awake()
    {
        i_width = Screen.width;
        i_height = Screen.height;
    }

    void Start()
    {      
        Screen.SetResolution(i_width, (i_width * 16) / 9, true);
    }
}
