using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrawnRecipeIcon : MonoBehaviour
{
    RectTransform rcTrans;

    private float fIconDestroyTime = 20f;
    [SerializeField] public Vector3 vUIPos;
    [SerializeField] public bool m_bIsDead = false;
    [SerializeField] public bool m_bIsClear = false;

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

    void LateUpdate()
    {
        if (m_bIsDead || m_bIsClear)
            Destroy(this.gameObject);
    }

    IEnumerator DeadRecipe()
    {
        if (!m_bIsDead)
        {
            yield return new WaitForSeconds(fIconDestroyTime);
            m_bIsDead = true;
        }
    }
}
