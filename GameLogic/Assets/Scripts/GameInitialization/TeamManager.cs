using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{

    //Creation des variables pour la list des equipes
    private List<GameObject> Team1;
    private List<GameObject> Team2;
    private bool boolTeamConstructed;
    private GameInitializer gameInitializer;

    private void Start()
    {
        Team1 = new List<GameObject>();
        Team2 = new List<GameObject>();
        boolTeamConstructed = false;
    }
    private void Awake()
    {
        gameInitializer = FindObjectOfType<GameInitializer>();
        gameInitializer.onSetupTeam += OnSetupTeamEventHandler;
    }

    private void OnDisable()
    {
        gameInitializer.onSetupTeam -= OnSetupTeamEventHandler;
    }

    public event EventHandler<OnTeamEventArg> onTeamInitialised;
    public class OnTeamEventArg : EventArgs
    {
        private List<GameObject> t1;
        private List<GameObject> t2;
        private bool isTeamConstructed;


        //property
        public List<GameObject> IntanceTeam1
        {

            get { return t1; }
            private set { t1 = value; }
        }

        public List<GameObject> IntanceTeam2
        {

            get { return t2; }
            private set { t2 = value; }
        }

        public bool IsTeamContructed
        {

            get { return isTeamConstructed; }
            private set { isTeamConstructed = value; }
        }

        //Constructor to init argument
        public OnTeamEventArg(List<GameObject> team1, List<GameObject> team2, bool isTeamConstruct)
        {
            t1 = team1;
            t2 = team2;
            isTeamConstructed = isTeamConstruct;
        }

    }
    private void OnTeam(OnTeamEventArg e)
    {
        onTeamInitialised?.Invoke(this, e);

    }
    private void OnSetupTeamEventHandler(object sender, GameInitializer.OnSetupTeamEventArg e)
    {
        boolTeamConstructed = CreationCharactere(e.List1, e.List2);
        OnTeam(new OnTeamEventArg(Team1, Team2, boolTeamConstructed));

    }
    public bool CreationCharactere(List<int> ch1, List<int> ch2)

    {
        if (ch1.Count > 0 && ch2.Count > 0)
        {
            try
            {
                //Instanciation Team 1
                foreach (var item in ch1)
                {
                    if (item > 0)
                    {
                        var prefab = Instantiate(DataContainer.singleton.character.listPrefabCharactere[item - 1], new Vector2(5000, 5000), Quaternion.identity);
                        Team1.Add(prefab);
                    }
                    else
                    {
                        Debug.LogError("Index Error for the Team 1");
                    }
                }

                //Instanciation Team 2
                foreach (var item in ch2)
                {
                    if (item > 0)
                    {
                        var prefab = Instantiate(DataContainer.singleton.character.listPrefabCharactere[item - 1], new Vector2(5000, 5000), Quaternion.identity);
                        Team2.Add(prefab);
                    }
                    else
                    {
                        Debug.LogError("Index Error for the Team 2");
                    }
                }

                return true;
            }
            catch
            {
                Debug.LogError("Instanciate Error");
                return false;
            }
        }
        else
        {
            Debug.LogError("List of team is empty");
            return false;
        }
    }
}

