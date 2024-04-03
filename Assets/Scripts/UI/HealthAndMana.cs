using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndMana : MonoBehaviour
{
    Character player;

    public Slider hpBar;
    public Slider mpBar;

    //private void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    //}

    private void Update()
    {
        if (player == null)
        {
            var playerList = GameObject.FindGameObjectsWithTag("Player");
            if (playerList.Length > 0) player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
            else return;
        }

        //float hp = player.health;
        //float maxHp = player.statBlock.GetStat("MaxHealth");
        //float mp = player.mana;
        //float maxMp = player.statBlock.GetStat("MaxMana");

        hpBar.value = player.health / player.statBlock.GetStat("MaxHealth");
        mpBar.value = player.mana / player.statBlock.GetStat("MaxMana");
    }
}
