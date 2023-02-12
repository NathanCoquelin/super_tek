using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekenesis : MonoBehaviour {

    public Transform playerCam;
    public float throwForce = 2000;

    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;
    private GameObject player;
    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    void Start()
    {
        player = GameObject.Find("MainCamera");
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (heldObj == null) {
                RaycastHit hit;
                float mana = player.GetComponent<PlayerStat>().get_current_mana();
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3. forward), out hit, pickupRange) && mana > 30) {
                    //&& hit.transform.gameObject.Active == true) {
                    PickupObject (hit.transform.gameObject);
                    player.GetComponent<PlayerStat>().current_mana -= 30;
                }
            } else {
                DropObject();
            }
        }
        if (heldObj != null) {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance (heldObj.transform.position, holdArea.position) > 0.1f) {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce (moveDirection * pickupForce);
        }
    }

    void PickupObject (GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>()) {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;
        heldObj.transform.parent = null;
        heldObjRB.AddForce(playerCam.forward * throwForce);
        heldObj = null;
    }

    public bool IsActive()
    {
        if (this.enabled) {
            return (true);
        } else {
            return (false);
        }
    }
}
