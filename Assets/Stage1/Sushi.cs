using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sushi : MonoBehaviour
{
    private GameObject player;
    private GameObject plate;

    private bool m_bIsHold = false;
    private bool m_bIsOnPlate = false;
    private bool m_bIsDead = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        plate = GameObject.FindWithTag("Plate");
        player.GetComponent<Player>().SetPlayerIsMove(true);
    }

    void Update()
    {
        m_bIsOnPlate = plate.GetComponent<Plate>().GetIsPlateOnFood();

        if (m_bIsHold)
            SetTransform(player.transform);
        else if (m_bIsOnPlate)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            transform.position = plate.transform.position;
        }
     //   else
     //       transform.position = this.transform.position;
    }

    void LateUpdate()
    {
        if (m_bIsDead)
            Destroy(this.gameObject);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!m_bIsHold)
                    m_bIsHold = true;
                else
                    m_bIsHold = false;
            }
        }

        if (other.gameObject.CompareTag("Plate"))
        {
            if (!m_bIsOnPlate)
                m_bIsOnPlate = true;
            plate.GetComponent<Plate>().SetIsPlateOnFood(true);
        }

        if (other.gameObject.CompareTag("PassCounter"))
            if (Input.GetKeyDown(KeyCode.Space) && m_bIsOnPlate)
                m_bIsDead = true;
    }

    void SetTransform(Transform pTrans)
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
        transform.position = pTrans.position + pTrans.forward;
        transform.position += new Vector3(0, 0.8f, 0);
    }
}
