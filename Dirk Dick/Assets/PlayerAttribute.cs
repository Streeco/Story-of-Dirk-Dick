using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class PlayerAttribute : MonoBehaviour
{
    DateTime now = DateTime.Now;
    string format = "dd MM yyyy  hh:mm";
    string loadDate;
    string saveDate;
    
    Vector3 playerPos;
    public static int Health = 5;

    // Start is called before the first frame update
    void Start()
    {
       DontDestroyOnLoad(gameObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
