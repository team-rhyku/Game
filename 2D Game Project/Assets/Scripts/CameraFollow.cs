using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 velocity;

    public float SmoothLiney;
    public float SmoothLinex;

    public GameObject player;

    public bool bounds;

    public Vector3 minCameraPos;

    public Vector3 maxCmameraPos;

    void start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

     void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, SmoothLinex);

        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, SmoothLiney);


        transform.position = new Vector3(posx, posy, transform.position.z);

        if(bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,minCameraPos.x,maxCmameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCmameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCmameraPos.z));
        }
    }

    public void SetMinCamPosition()
    {
        minCameraPos = gameObject.transform.position;
    }

    public void SetMaxCamPosition()
    {
        maxCmameraPos = gameObject.transform.position;
    }

}
