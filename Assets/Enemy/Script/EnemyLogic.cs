using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int hp = 100;
    public int attack = 10;

    private Transform cam_t;
    private PlayerStat player_stat;
    // Start is called before the first frame update
    void Start()
    {
        player_stat = GameObject.Find("RigidBodyFPSController").GetComponent<Camera>().GetComponent<PlayerStat>(); 
        cam_t = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(cam_t);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }

    void Update() {
        if (Vector3.Distance(cam_t.position, this.transform.position) <= 5) {
            player_stat.attack(attack);
        }
    }

    public int add_en_attack(int dmg) {
        attack += dmg;
        return attack;
    }
}