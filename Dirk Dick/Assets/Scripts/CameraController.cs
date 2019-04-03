using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    //public bool bounds = false;

    //public Vector3 minCameraPos;
    //public Vector3 maxCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        //if(bounds == true)
        //{
        //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
        //        Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
        //        Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        //}
    }
}
