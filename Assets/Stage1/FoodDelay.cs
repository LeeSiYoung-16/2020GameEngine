using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodDelay : MonoBehaviour
{
    RectTransform rcTrans;

    private float DestroyTime = 5f;
    private bool m_bIsDead = false;
    private Slider slTimer;

    public Vector3 vUIPos;

    private void Awake()
    {
        this.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
    }

    void Start()
    {
        rcTrans = GetComponent<RectTransform>();
        slTimer = GetComponent<Slider>();
    }

    void Update()
    {
        this.rcTrans.position = Camera.main.WorldToScreenPoint(vUIPos);

        if (slTimer.value < 5f)
            slTimer.value += 1f * Time.deltaTime;
        
        StartCoroutine(DeadFood());
    }

    private void LateUpdate()
    {
        if (m_bIsDead)
            Destroy(this.gameObject);
    }

    IEnumerator DeadFood()
    {
        if (!m_bIsDead)
        {
            yield return new WaitForSeconds(DestroyTime);
            m_bIsDead = true;
        }
    }
}
