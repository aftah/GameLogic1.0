using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{

    //Creation des variables pour la list des equipes
    private List<GameObject> Team1;
    private List<GameObject> Team2;
    private bool boolteamOk;

    private void Start()
    {
        Team1 = new List<GameObject>();
        Team2 = new List<GameObject>();
        boolteamOk = false;
    }
    private void Awake()
    {
        FindObjectOfType<GameInitializer>().onSetupTeam += OnSetupTeamEventHandler;           
    }

   

    public event EventHandler<OnTeamEventArg> onTeamInitialised;
    public class OnTeamEventArg : EventArgs
    {
        public List<GameObject> T1 = new List<GameObject>() ;
        public List<GameObject> T2 = new List<GameObject>();

        public bool isTeamOk;

      

    }
    private void OnTeam(OnTeamEventArg e)
    {
        if (onTeamInitialised != null)
        {
            //e.T1 = Team1;
            //e.T2 = Team2;
            //e.isTeamOk = boolteamOk;

            //Team1 = e.T1;
            //Team2 = e.T2;
            
            onTeamInitialised(this, e); // déclenche l'événement        
        }

       
    }
    private void OnSetupTeamEventHandler(object sender, GameInitializer.OnSetupTeamEventArg e)
    {
       boolteamOk = CreationCharactere(e.list1, e.list2);
        OnTeam(new OnTeamEventArg { T1 = Team1, T2 = Team2, isTeamOk = boolteamOk});

    }
    public bool CreationCharactere(List<int> ch1, List<int> ch2)

    {

        //Instanciation Team 1
        foreach (var item in ch1)
        {
            var prefab = Instantiate(DataContainer.singleton.character.listPrefabCharactere[item - 1],new Vector2(1,1),Quaternion.identity);
            
            Team1.Add(prefab);
        }



        //Instanciation Team 2
        foreach (var item in ch2)
        {
            var prefab = Instantiate(DataContainer.singleton.character.listPrefabCharactere[item - 1], new Vector2(1, 1), Quaternion.identity);
            Team2.Add(prefab);
        }

        return true;

    }
}

