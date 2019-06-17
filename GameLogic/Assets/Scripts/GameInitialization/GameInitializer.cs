using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{

 
	public Dictionary<Vector3, GameObject> obstaclesDictionary;

	private List<Vector3> obstaclePosition;
	private List<GameObject> obstacleObject;


	public event EventHandler<OnSetupMapEventArg> onSetupMap;
	public event EventHandler<OnSetupTeamEventArg> onSetupTeam;
	public event EventHandler<OnSetupUIEventArg> onSetupUI;
	public event EventHandler<OnModeEventArg> onMode;

	private void Awake()
	{
		FindObjectOfType<MenuManager>().onGameInitialise += OnGameInitializeEventHandler;
		//FindObjectOfType<ObstacleDictionary>().onLoadArena += OnLoadArenaEventHandler;

		obstaclesDictionary = new Dictionary<Vector3, GameObject>();

		
	}

	//private void OnLoadArenaEventHandler(object sender, ObstacleDictionary.ObstacleDictionaryEventArgs e)
	//{
	//    obstaclesDictionary = e.obstaclesDictionary;
	//}

	public class OnSetupMapEventArg : EventArgs
	{
		public int MapIndex;
		public bool isMapReady;
	}

	public class OnModeEventArg : EventArgs 
	{
		public int Mode;
	}
	public class OnSetupUIEventArg : EventArgs
	{

	}

	public class OnSetupTeamEventArg : EventArgs
	{
		public List<int> list1 = new List<int>();
		public List<int> list2 = new List<int>();

        
	}

	


	private void OnSetupUI(OnSetupUIEventArg e)
	{
		onSetupUI?.Invoke(this, e);  

	}
	private void OnMode(OnModeEventArg e)
	{
		onMode?.Invoke(this, e); 
	}
	private void OnSetupMap(OnSetupMapEventArg e)
	{

		onSetupMap?.Invoke(this, e);
	}

	private void OnSetupTeam(OnSetupTeamEventArg e)
	{
        
		onSetupTeam?.Invoke(this, e);

	}

	private void OnGameInitializeEventHandler(object sender, MenuManager.OnGameInitializeEventArgs e)
	{
		Debug.Log("--------------");
		OnSetupTeam(new OnSetupTeamEventArg { list1 = e.charactersPlayer1 , list2 = e.charactersPlayer2  });
		
		OnSetupMap(new OnSetupMapEventArg { isMapReady = InstanciateMap(e.mapIndex) });
		OnMode(new OnModeEventArg { Mode = e.charactersPlayer1.Count }); 
	}

	public bool InstanciateMap(int mapIndex)
	{
		Dictionary<Vector3, GameObject> mondico = GetLevelDictionary(mapIndex);

		foreach (var item in mondico)
		{
			Instantiate(item.Value, item.Key, item.Value.transform.rotation);
		}

		
		return true;
	}

	public Dictionary<Vector3, GameObject> GetLevelDictionary(int arenaIndex)
	{
		if (obstaclesDictionary != null)
			obstaclesDictionary.Clear();

		obstaclePosition = DataContainer.singleton.metaData.DataList[arenaIndex].arena.obstaclesPosition;
		obstacleObject = DataContainer.singleton.metaData.DataList[arenaIndex].arena.obstaclesObject;

		obstaclesDictionary = new Dictionary<Vector3, GameObject>();

		for (int i = 0; i < obstaclePosition.Count; i++)
		{
			obstaclesDictionary.Add(obstaclePosition[i], obstacleObject[i]);
		}

		return obstaclesDictionary;

	}

	public void ExecuteDebug()
	{


		OnSetupTeam(new OnSetupTeamEventArg { list1 = new List<int> { 1, 4, 9, 10 }, list2 = new List<int> { 2, 5, 7, 12 } });
        
		OnSetupMap(new OnSetupMapEventArg { isMapReady = InstanciateMap(0) });
		OnMode(new OnModeEventArg { Mode = 4 });

		foreach (var item in obstaclesDictionary)
		{
			Debug.Log(item.Key);
			Debug.Log(item.Value);
		}
	}

}

