using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopPrawn : MonoBehaviour
{
    public PrawnSushi prawnSushi;
    public PrawnSushi prawnSushiClone;

    private float DestroyTime = 5f;
    private bool m_bIsDead = false;

    public FoodDelay foodDelay;
    public FoodDelay foodDelayClone;

    void Start()
    {
        foodDelayClone = Instantiate(foodDelay, transform.position, Quaternion.identity);
    }

    void Update()
    {
        foodDelayClone.vUIPos = new Vector3(this.transform.position.x,
            this.transform.position.y,
            this.transform.position.z + 1f);
        StartCoroutine(CreateSushi());
    }

    void LateUpdate()
    {
        if (m_bIsDead)
        {
            prawnSushiClone = Instantiate(prawnSushi, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    IEnumerator CreateSushi()
    {
        if (!m_bIsDead)
        {
            yield return new WaitForSeconds(DestroyTime);
            m_bIsDead = true;
        }
    }
}
