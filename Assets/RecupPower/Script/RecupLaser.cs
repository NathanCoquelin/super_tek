using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecupLaser : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("MainCamera");
    }

    void Update()
    {
        transform.LookAt(player.transform);
    }
    void OnCollisionEnter(Collision collision)
    {
        player.GetComponent<Laser>().enabled = true;
        Destroy(this.gameObject);
    }
}
