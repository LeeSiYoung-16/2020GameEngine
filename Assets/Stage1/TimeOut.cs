using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOut : MonoBehaviour
{
    private float fSceneTime = 60f;
    
    private float fsecTime = 60f;
    private int iminTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fsecTime != 0)
        {
            fsecTime -= Time.deltaTime;
            if (fsecTime <= 0)
            {
                fsecTime = 60;
                if (iminTime > 0)
                    iminTime--;
                else
                    iminTime = 0;
            }
        }
        int sec = Mathf.FloorToInt(fsecTime);

        Text TimerText = GetComponent<Text>();
        if(sec >= 10)
            TimerText.text = "0" + iminTime.ToString() + ":" + sec.ToString();
        else
            TimerText.text = "0" + iminTime.ToString() + ":" + "0" + sec.ToString();
    }

    void LateUpdate()
    {
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(fSceneTime);
        Application.LoadLevel("Stage2");
    }
}
