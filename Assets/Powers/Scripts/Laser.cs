using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    public Camera playerCamera;
    public Transform laserOrigin;
    public float laserRange = 50f;
    public float laserDuration = 1.5f;
    float timer = 0f;
    public float cooldown = 2f;
    LineRenderer laserLine;
    public bool canUse = false;
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timer > cooldown && canUse == true) {
            timer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, laserRange)) {
                laserLine.SetPosition(1, hit.point);
                //enemy reculer
            } else {
                //laserLine.SetPosition(1, playerCamera
            }
            StartCoroutine(LaserShoot());                                                                      
        }
    }

    IEnumerator LaserShoot()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
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
