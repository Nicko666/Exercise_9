using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Player player;

    [SerializeField] private Text healthBar;
    [SerializeField] private Text message;

    private void OnEnable()
    {
        Renew();
    }

    public void Renew()
    {
        healthBar.text = player.health.ToString();
    }

    public void Damage(int value)
    {
        healthBar.text = player.health.ToString();
        message.text = $"You took {value} damage point(s)";
    }
}
