using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowText : MonoBehaviour
{
    private GameObject healthGameObject;
    private TMP_Text hpText;
    public int hp;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("MainCamera");
        healthGameObject = GameObject.Find("Canvas/Hp");
        hpText = healthGameObject.GetComponent<TMP_Text>();
        hpText.text = ("HP\n" + hp);
    }
    void Update()
    {
        hp = player.GetComponent<PlayerStat>().get_hp();
        hpText.text = ("HP\n" + hp);
    }
}
