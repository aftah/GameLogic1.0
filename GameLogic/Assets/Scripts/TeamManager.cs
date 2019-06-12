using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{

    //Creation des variables pour la list des equipes
    private void Awake()
    {
        FindObjectOfType<GameInitializer>().onTeam += OnTeamListernerHandler;

    }

    private void OnTeamListernerHandler(object sender, GameInitializer.TeamEventArg e)
    {
        //boucle de initialisation
    }
}
