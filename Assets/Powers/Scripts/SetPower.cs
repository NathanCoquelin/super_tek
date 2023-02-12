using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPower : MonoBehaviour
{
    private int state = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            print("telekenesis");
            GetComponent<Telekenesis>().canUse = true;
            GetComponent<Projectiles>().canUse = false;
            GetComponent<Laser>().canUse = false;
        }
        if (Input.GetKeyDown(KeyCode.Ampersand)) {
            print("projectile");
            GetComponent<Telekenesis>().canUse = false;
            GetComponent<Projectiles>().canUse = true;
            GetComponent<Laser>().canUse = false;
        }

        if (Input.GetKeyDown(KeyCode.DoubleQuote)) {
            print("laser");
            GetComponent<Telekenesis>().canUse = false;
            GetComponent<Projectiles>().canUse = false;
            GetComponent<Laser>().canUse = true;
        }
    }
}