using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconOn : MonoBehaviour
{
    private GameObject player;
    private GameObject laserIcon;
    private GameObject TelekenesisIcon;
    void Start()
    {
        player = GameObject.Find("MainCamera");
        laserIcon = GameObject.Find("Canvas/Laser");
        TelekenesisIcon = GameObject.Find("Canvas/Telekenesis");

    }

    void Update()
    {
        if (player.GetComponent<Laser>().IsActive())
            laserIcon.SetActive(true);
        else
            laserIcon.SetActive(false);
        if (player.GetComponent<Telekenesis>().IsActive())
            TelekenesisIcon.SetActive(true);
        else
            TelekenesisIcon.SetActive(false);
    }
}

