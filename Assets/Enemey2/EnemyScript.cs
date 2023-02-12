using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int hp = 3;
    private bool move_right = false;
    void OnCollisionEnter(Collision collision)
    {
        hp--;
        if (hp == 0) {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "RigidBodyFPSController")
            print("it detect");
    }
}
