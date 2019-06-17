using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int selectedMode;
    public List<GameObject> Team1;
    public List<GameObject> Team2;


    private bool teamReady = false;
    private bool mapReady = false;
    private bool modeReady = false;

    public event EventHandler<GameReadyArgs> GameReady;

    private void Awake()
    {
        FindObjectOfType<GameInitializer>().onMode += OnModeEventHandler;
        FindObjectOfType<TeamManager>().onTeamInitialised += GameManager_onTeamInitialised;
       
    }

    private void GameManager_onTeamInitialised(object sender, TeamManager.OnTeamEventArg e)
    {
        Team1 = e.T1;
        Team2 = e.T2;
        teamReady = true;
        CheckReady();
    }

    private void CheckReady()
    {
        if (teamReady && mapReady && modeReady)
        {
            GameReady?.Invoke(this, new GameReadyArgs());
        }
    }

    private void Start()
    {
        
        selectedMode = 0;
    }
    private void OnTeamEventHandler(object sender, TeamManager.OnTeamEventArg e)
    {
       
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

       
    }
    public class OnGameInitializedEventArg : EventArgs 
    {
    }

    public event EventHandler<OnStartEventArg> onStart;
    public event EventHandler<OnEndEventArg> onEnd;
    public event EventHandler<GameManager.OnTeamConstructedEventArg> onTeamConstructed;

    private void OnStart(OnStartEventArg e)
    {
        if (onStart != null)
        {
            onStart(this, e);
        }
    }

    private void OnEnd(OnEndEventArg e)
    {
        if (onEnd != null)
        {
            onEnd(this, e);
        }
    }
    private void OnTeamConstructed(OnTeamConstructedEventArg e)
    {

        if (onTeamConstructed != null)
        {
            onTeamConstructed(this,e);
        }
    }

	private void OnModeEventHandler(object sender,GameInitializer.OnModeEventArg   e)
	{
        selectedMode = e.Mode;
        OnStart(new OnStartEventArg());
      
       
	}

   
}

