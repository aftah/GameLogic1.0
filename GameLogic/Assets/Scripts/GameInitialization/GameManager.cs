using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int selectedMode=0;
    public List<GameObject> Team1;
    public List<GameObject> Team2;


    private bool teamReady = false;
    private bool mapReady = false;
    private bool modeReady = false;

    public event EventHandler<GameReadyArgs> GameReady;
    public event EventHandler<OnStartEventArg> onStart;
    public event EventHandler<OnEndEventArg> onEnd;
    public event EventHandler<OnTeamConstructedEventArg> onTeamConstructed;

    private void Awake()
    {
        FindObjectOfType<GameInitializer>().onMode += OnModeEventHandler;
        FindObjectOfType<TeamManager>().onTeamInitialised += OnTeamInitialisedEventHandler;
       
    }

    private void OnTeamInitialisedEventHandler(object sender, TeamManager.OnTeamEventArg e)
    {
        OnTeamConstructed(new OnTeamConstructedEventArg { Team1 = e.T1, Team2 = e.T2, boolTeamConstruted = e.isTeamOk });
       
    }

    //private void OnTeamInitialised(object sender, TeamManager.OnTeamEventArg e)
    //{
    //    //Team1 = e.T1;
    //    //Team2 = e.T2;
    //    //teamReady = e.isTeamOk;
    //   OnTeamInitialised(new )

    //    CheckReady();
    //}

    private void CheckReady()
    {
        if (teamReady && modeReady)
        {
            GameReady?.Invoke(this, new GameReadyArgs());
        }
    }

    private void Start()
    {
        Team1 = new List<GameObject>();
        Team2 = new List<GameObject>();
       
    }
   

    public class GameReadyArgs : EventArgs
    {

    }

    public class OnStartEventArg : EventArgs 
    {
    }

    public class OnEndEventArg : EventArgs 
    {
    }

    public class OnTeamConstructedEventArg : EventArgs
    {

        public List<GameObject> Team1 = new List<GameObject>();
        public List<GameObject> Team2 = new List<GameObject>();

        public bool boolTeamConstruted;
    }
    public class OnGameInitializedEventArg : EventArgs 
    {
    }

   

    private void OnStart(OnStartEventArg e)
    {
        onStart?.Invoke(this, e);
    }

    private void OnEnd(OnEndEventArg e)
    {
        onEnd?.Invoke(this, e);
    }
    private void OnTeamConstructed(OnTeamConstructedEventArg e)
    {
        Team1 = e.Team1;
        Team2 = e.Team2;
        teamReady = e.boolTeamConstruted;
        CheckReady();
        DebugTeam();

        onTeamConstructed?.Invoke(this, e);
        
    }

	private void OnModeEventHandler(object sender,GameInitializer.OnModeEventArg   e)
	{
        selectedMode = e.Mode;
        //OnStart(new OnStartEventArg());
      
       
	}

 public void DebugTeam()
    {

        /////////////////////////////////////////////////////////////////////////test
        foreach (var item in Team1)
        {
            Debug.Log(item.gameObject.name);

        }

        foreach (var item in Team2)
        {
            Debug.Log(item.gameObject.name);

        }
        ////////////////////////////////////////////////////////////////////////////test
    }
}

