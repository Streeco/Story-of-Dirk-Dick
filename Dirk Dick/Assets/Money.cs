using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static int moneyValue = 0;
    TextMesh money;

    // Start is called before the first frame update
    void Start()
    {
        money = GetComponent<TextMesh>(); 
    }

    // Update is called once per frame
    void Update()
    {
        money.text = " " + moneyValue;
    }
}
