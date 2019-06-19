using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{

    //private variables

    private Dictionary<Vector3, GameObject> obstaclesDictionary;
    private List<Vector3> obstaclePosition;
    [SerializeField]
    private List<GameObject> obstacleObject;
    [SerializeField]
    private int Mapindex;
    [SerializeField]
    private bool boolMapConstruted;




    //Event
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
        private int mapIndex;
        private bool boolMapReady;

        public int MapIndex
        {
            get { return mapIndex; }
            private set { mapIndex = value; }
        }

        public bool BoolMapReady
        {
            get { return boolMapReady; }
            private set { boolMapReady = value; }
        }

        public OnSetupMapEventArg(int IndexMap)
        {
            mapIndex = IndexMap;

        }
        public OnSetupMapEventArg(bool isMapReady, int indexMap)
        {
            boolMapReady = isMapReady;
            mapIndex = indexMap;
        }

    }
    public class OnModeEventArg : EventArgs
    {
        private int mode;
        public int Mode
        {
            get { return mode; }
            private set { mode = value; }
        }


        public OnModeEventArg(int gameMode)
        {
            mode = gameMode;
        }
    }
    public class OnSetupUIEventArg : EventArgs
    {

    }
    public class OnSetupTeamEventArg : EventArgs
    {
        private List<int> list1;
        private List<int> list2;

        public List<int> List1
        {
            get { return list1; }
            private set { list1 = value; }
        }

        public List<int> List2
        {
            get { return list2; }
            private set { list2 = value; }
        }

        public OnSetupTeamEventArg(List<int> l1, List<int> l2)
        {
            list1 = l1;
            list2 = l2;
        }

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
        Mapindex = e.MapIndex;
        boolMapConstruted = e.BoolMapReady;
        onSetupMap?.Invoke(this, e);
    }
    private void OnSetupTeam(OnSetupTeamEventArg e)
    {

        onSetupTeam?.Invoke(this, e);

    }

    private void OnGameInitializeEventHandler(object sender, MenuManager.OnGameInitializeEventArgs e)
    {

        OnSetupTeam(new OnSetupTeamEventArg(e.charactersPlayer1, e.charactersPlayer2));

        OnSetupMap(new OnSetupMapEventArg(InstanciateMap(e.mapIndex), e.mapIndex));
        OnMode(new OnModeEventArg(e.charactersPlayer1.Count));
    }

    public bool InstanciateMap(int mapIndex)
    {
        Dictionary<Vector3, GameObject> mondico = GetLevelDictionary(mapIndex);

        if (mondico.Values.Count > 0)
        {
            try
            {
                foreach (var item in mondico)
                {
                    Instantiate(item.Value, item.Key, item.Value.transform.rotation);
                }
                return true;
            }
            catch
            {
                return false;

            }
        }
        else
        {
            return false;
        }

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

        OnSetupTeam(new OnSetupTeamEventArg(new List<int> { 1, 4, 9, 10 }, new List<int> { 2, 5, 7, 12 }));

        OnSetupMap(new OnSetupMapEventArg(InstanciateMap(0), 0));

        OnMode(new OnModeEventArg(4));

    }

}

