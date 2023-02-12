using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider manaSlider;
    private GameObject player;
    public int mana;

    void Start()
    {
        player = GameObject.Find("MainCamera");
        manaSlider.maxValue = 180; //player.GetComponent<PlayerStat>().get_current_mana();
        manaSlider.value = player.GetComponent<PlayerStat>().get_current_mana();
    }
    void Update()
    {
        manaSlider.value = player.GetComponent<PlayerStat>().get_current_mana();
    }
}
