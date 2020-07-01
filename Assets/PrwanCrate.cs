using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrwanCrate : MonoBehaviour
{
    public Prawn prawn;
    public Prawn prawnClone;
    private bool m_bIsHold = false;

    void Start()
    {
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !m_bIsHold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                prawnClone = Instantiate(prawn, transform.position, Quaternion.identity);
                m_bIsHold = true;
                prawnClone.SetIsHold(m_bIsHold);
            }
        }
    }

    void Update()
    {
        m_bIsHold = prawn.GetIsHold();
    }
}
