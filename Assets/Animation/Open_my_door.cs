using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_my_door : MonoBehaviour
{
    public float open = 100f;
    public float range = 10f;
    public GameObject door;
    public bool isOpening = false;
    public Camera fpsCam;

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
    
            Door target = hit.transform.GetComponent<Door>();
            if (target != null){
                StartCoroutine(OpenDoor());
            }
        }
    }

    IEnumerator OpenDoor(){
        isOpening = true;
        door.GetComponent<Animator>().Play("Open_door");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(5.0f);
        door.GetComponent<Animator>().Play("Close_door");
        isOpening = false;
    }
}
