using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EXIT_WORLD : MonoBehaviour
{
    public float open = 100f;
    public float range = 10f;
    public GameObject door;
    public bool isOpening = false;
    public Camera fpsCam;


    void OpenDoor(){
        SceneManager.LoadScene("HUB_EPITECH");
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
    
            Portal_lake_i target = hit.transform.GetComponent<Portal_lake_i>();
            if (target != null){
                OpenDoor();
            }
        }
    }
}
