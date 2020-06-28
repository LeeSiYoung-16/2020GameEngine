using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    private float fAddTime = 0f;
    
    // 처음에 2개 10초에 하나씩
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fAddTime += Time.deltaTime;

        if(fAddTime >= 10f)
        {
            fAddTime = 0f;

        }
    }

    void LateUpdate()
    {
    }

}
