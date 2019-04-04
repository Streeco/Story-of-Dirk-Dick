using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShopInteraction : MonoBehaviour
{
    Scene currentScene = SceneManager.GetActiveScene();


    // Start is called before the first frame update
    void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Streets")
        {

        }

    }



    // Update is called once per frame
    void Update()
    {
        string sceneName = currentScene.name;

        if (Input.GetKeyUp(KeyCode.B) && sceneName == "Streets")
        {

            SceneManager.LoadScene("StokShop", LoadSceneMode.Single);
        }

        if (Input.GetKeyUp(KeyCode.B) && sceneName == "Shop")
        {

            SceneManager.LoadScene("Streets", LoadSceneMode.Single);
        }
    }

    

}
