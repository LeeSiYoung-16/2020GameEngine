using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 5f;

    Rigidbody rigidbody;
    Vector3 movement;
    float h, v;

    private bool m_bIsMove = true;
    private int m_iCoin = 0;
    private int m_iPlusCoin = 0;

    public void SetPlayerIsMove(bool bIsMove) { m_bIsMove = bIsMove; }
    public bool GetPlayerIsMove() { return m_bIsMove; }

    public void SetAddCoin(int iCoin) { m_iCoin += iCoin; }
    public void SetPlusCoin(int iCoin) { m_iPlusCoin = iCoin; }
    public int GetPlusCoin() { return m_iPlusCoin; }
    public int GetCoin() { return m_iCoin; }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = -Input.GetAxisRaw("Horizontal");
        v = -Input.GetAxisRaw("Vertical");
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.RightShift))
            Application.LoadLevel("Stage2");
    }

    void FixedUpdate()
    {
        if(m_bIsMove)
        {
            PlayerMove();
            PlayerTurn();
        }
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 8f;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            speed = 5f;

        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        rigidbody.MovePosition(transform.position + movement);
    }

    private void PlayerTurn()
    {
        if (h == 0 && v == 0) return;

        Quaternion newRotation = Quaternion.LookRotation(movement);
        rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, newRotation, speed * Time.deltaTime);
    }
}
