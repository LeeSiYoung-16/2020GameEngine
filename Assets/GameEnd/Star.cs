using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    RectTransform rcTrans;
    [SerializeField] public Vector3 vUIPos;

    private void Awake()
    {
        this.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rcTrans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rcTrans.position = vUIPos;
    }
}
