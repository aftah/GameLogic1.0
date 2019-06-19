using System;
using System.Collections.Generic;
using UnityEngine;




public class GameManager : MonoBehaviour
{
	[SerializeField]
	private int selectedMode=0;
	[SerializeField]
	private List<GameObject> Team1;
	[SerializeField]
	private List<GameObject> Team2;

	[SerializeField]
	private bool boolTeamConstructed;

	private enum GameMode
	{

		Mode1v1,
		Mode2v2,
		Mode3v3,
		Mode4v4
	};
	[SerializeField]
	private GameMode gameMode;
	

	
	public event EventHandler<OnStartEventArg> onStart;
	public event EventHandler<OnEndEventArg> onEnd;
	public event EventHandler<OnTeamConstructedEventArg> onTeamConstructed;

	private void Awake()
	{
		FindObjectOfType<GameInitializer>().onMode += OnModeEventHandler;
		FindObjectOfType<TeamManager>().onTeamInitialised += OnTeamInitialisedEventHandler;
	   
	}

   

	public class OnStartEventArg : EventArgs 
	{
	}

	public class OnEndEventArg : EventArgs 
	{
	}

	public class OnTeamConstructedEventArg : EventArgs
	{

		private List<GameObject> t1;
		private List<GameObject> t2;
		private bool boolTeamConstruted;

		public List<GameObject> Team1
		{
			get { return t1; }
			private set { t1 = value; }
		
		}

		public List<GameObject> Team2
		{
			get { return t2; }
			private set { t2 = value; }

		}

		public bool BoolTeamConstruted
		{
			get { return boolTeamConstruted; }
			private set { boolTeamConstruted = value; }

		}

		public OnTeamConstructedEventArg(List<GameObject> team1,List<GameObject> team2, bool boolTeamConstruct)
		{

			t1 = team1;
			t2 = team2;
			boolTeamConstruted = boolTeamConstruct;
			
			
		}



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
		boolTeamConstructed = e.BoolTeamConstruted;
	   
	   
		onTeamConstructed?.Invoke(this, e);
		
	}

	private void OnTeamInitialisedEventHandler(object sender, TeamManager.OnTeamEventArg e)
	{
		OnTeamConstructed(new OnTeamConstructedEventArg( e.IntanceTeam1,e.IntanceTeam2, e.IsTeamContructed));

	}
	private void OnModeEventHandler(object sender,GameInitializer.OnModeEventArg   e)
	{

		selectedMode = e.Mode;

		//switch (selectedMode)
		//{
		//    case 0:

		//    case 1:

		//    case 2:

		//    case 4:


		//    default: break;
		//}

		if (boolTeamConstructed)
		{
			OnStart(new OnStartEventArg());

		}
	}

 
}

