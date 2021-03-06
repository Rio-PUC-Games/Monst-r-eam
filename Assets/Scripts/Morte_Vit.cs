﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Morte_Vit : MonoBehaviour
{

    /* Verifica se o jogo acabou ao comparar o contador de vitorias e mortes com o numero de players
       se houver pelo menos uma vitoria, a cena de vitoria sera carregada, caso contrario
       a cena de derrota sera carregada.

        Autores: Vinny
    */

    public GameObject[] Lemmings;
    private int Count;

    // Start is called before the first frame update
    void Start()
    {
        Count = Lemmings.Length; // Pega o numero de Players
    }

    // Update is called once per frame
    void Update()
    {
        if(Count == (Vitoria.WinCount + Morte.DeathCount)) // Compara com o numero de vitorias e derrotas
        {
            End(); // funcao que faz vitoria ou derrota aparecer
            PlayerInput.Unregister();
        }
    }
    private void End()
    {
        if(Vitoria.WinCount > 0)
        {
			GameObject.Find("UIprefab").GetComponent<ChangeScene>().VictoryScreen();
            
            //toca som de ganhar a fase com tantas estrelas
            string str = "Vitoria" + Vitoria.WinCount.ToString();
            SoundSystem.PlaySound(str);

            //seta no save que a fase foi ganha, e com tantas estrelas
            SaveSystem.GetInstance().SetScoreForCurrentLevel(Vitoria.WinCount, true, new bool[]{Vitoria.ZeVit, Vitoria.DedeVit, Vitoria.ManeVit });  
        }
        else
        {
			GameObject.Find("UIprefab").GetComponent<ChangeScene>().LoseScreen();
            Vitoria.WinCount = 0; // pra nao bugar
            Morte.DeathCount = 0; // pra nao bugar
		}
    }
}
