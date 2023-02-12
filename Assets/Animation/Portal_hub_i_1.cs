using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_hub_i1 : MonoBehaviour
{
    public float health = 1f;

    public void Open (float amount){
        health -= amount;
        if (health <= 0f)
            Die();
    }

    void Die (){
       Destroy(gameObject);
    }
}
