using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchForPrefabs : MonoBehaviour
{
    
    private GameObject mcDingleStokGun;
    private GameObject mcDingleStok;
    private GameObject mcDingleStokana;
    private GameObject mcDingleStokZooka;
    Player_Movement_Stokgun playerAnimationStartSG;
    Player_Movement_Stok playerAnimationStartS;

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject mcDingleStokGun = GameObject.Find("McDinglenutsShutgun");
        playerAnimationStartSG = mcDingleStokGun.GetComponent<Player_Movement_Stokgun>();
        GameObject mcDingleStok = GameObject.Find("McDinglenutsCane");
        playerAnimationStartS = mcDingleStok.GetComponent<Player_Movement_Stok>();




    }
    
    // Update is called once per frame
    void Update()
    {
        if (mcDingleStokGun.activeSelf)
        {
            playerAnimationStartSG.stokGun = true;
        }
        else
        {
            playerAnimationStartSG.stokGun = false;
        }

        if (mcDingleStok.activeSelf)
        {
            playerAnimationStartS.stok = true;
        }
        else
        {
            playerAnimationStartS.stok = false;
        }
        
    }
}
