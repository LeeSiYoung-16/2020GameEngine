using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float offsetX = 0f;
    public float offsetY = 9f;
    public float offsetZ = 3f;

    private GameObject player;
  //  public Transform target;
    Vector3 cameraPos;   

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Screen.fullScreen = false;
    }

    void LateUpdate()
    {
        cameraPos.x = player.GetComponent<Player>().transform.position.x + offsetX;
        cameraPos.y = player.GetComponent<Player>().transform.position.y + offsetY;
        cameraPos.z = player.GetComponent<Player>().transform.position.z + offsetZ;

        //cameraPos.x = target.position.x + offsetX;
        //cameraPos.y = target.position.y + offsetY;
        //cameraPos.z = target.position.z + offsetZ;
        transform.position = Vector3.Lerp(transform.position, cameraPos, 3f * Time.deltaTime);
    }
}
