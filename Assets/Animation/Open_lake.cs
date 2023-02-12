using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open_lake : MonoBehaviour
{
    public float open = 100f;
    public float range = 10f;
    public GameObject door;
    public bool isOpening = false;
    public Camera fpsCam;


    void OpenDoor(){
        SceneManager.LoadScene("Lake");
    }
    void Update (){
        if (Input.GetKeyDown("e"))
        {
            Shoot();
        }
    }
    void Shoot () {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
    
            Portal_hub_i_1 target = hit.transform.GetComponent<Portal_hub_i_1>();
            if (target != null){
                OpenDoor();
            }
        }
    }
}
