﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morte : MonoBehaviour
{
    /* Testa colisao entre o objeto Player e o Obstaculo,
       caso haja colisao o GameObject do Player se torna Inativo e o contador de mortes sobe

       Autores: Vinny
    */
    public static int DeathCount = 0;
    public static bool ZeMorto;
    public static bool DedeMorto;
    public static bool ManeMorto;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ZeTag")
        {
            var pd = collision.gameObject.GetComponent<PlayerDeath>();
            if(pd != null) pd.KillPlayer();
            ZeMorto = true;
            Vitoria.ZeVit = false;
            DeathCount++;
            Debug.Log("ZePerdi");
        }
        if (collision.gameObject.tag == "DedeTag")
        {
            var pd = collision.gameObject.GetComponent<PlayerDeath>();
            if(pd != null) pd.KillPlayer();
            DedeMorto = true;
            Vitoria.DedeVit = false;
            DeathCount++;
            Debug.Log("DedePerdi");
        }
        if (collision.gameObject.tag == "ManeTag")
        {
            var pd = collision.gameObject.GetComponent<PlayerDeath>();
            if(pd != null) pd.KillPlayer();
            ManeMorto = true;
            Vitoria.ManeVit = false;
            DeathCount++;
            Debug.Log("ManePerdi");
        }
    }
}
