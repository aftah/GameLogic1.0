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

    private MenuManager menuManager;


    //Event
    public event EventHandler<OnSetupMapEventArg> onSetupMap;
    public event EventHandler<OnSetupTeamEventArg> onSetupTeam;
    public event EventHandler<OnModeEventArg> onMode;

    private void Awake()
    {
        obstaclesDictionary = new Dictionary<Vector3, GameObject>();
        menuManager = FindObjectOfType<MenuManager>();
        menuManager.onGameInitialise += OnGameInitializeEventHandler;


        obstaclesDictionary = new Dictionary<Vector3, GameObject>();


    }

    private void OnDisable()
    {
        menuManager.onGameInitialise -= OnGameInitializeEventHandler;
    }



    public class OnSetupMapEventArg : EventArgs
    {
        private int mapIndex;
        private bool boolMapReady;
        private Dictionary<Vector3, GameObject> _obstaclesDictionary;

        public Dictionary<Vector3, GameObject> ObstaclesDictionary
        {
            get { return _obstaclesDictionary; }
            private set { _obstaclesDictionary = value; }
        }

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


        public OnSetupMapEventArg(Dictionary<Vector3, GameObject> obstacleDico, int indexMap, bool isMapReady)
        {
            boolMapReady = isMapReady;
            mapIndex = indexMap;
            _obstaclesDictionary = obstacleDico;
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

        OnSetupMap(new OnSetupMapEventArg(obstaclesDictionary, e.mapIndex, InstanciateMap(e.mapIndex)));

        OnMode(new OnModeEventArg(e.charactersPlayer1.Count));
    }

    public bool InstanciateMap(int mapIndex)
    {
        Dictionary<Vector3, GameObject> mapDictionary = GetLevelDictionary(mapIndex);

        if (mapDictionary.Values.Count > 0)
        {
            try
            {
                foreach (var item in mapDictionary)
                {
                    Instantiate(item.Value, item.Key, item.Value.transform.rotation);
                }
                return true;
            }
            catch
            {
                Debug.LogError("Error instanciate Obstacle dictionnary for the map" + mapIndex);
                return false;

            }
        }
        else
        {
            Debug.LogError("Obstacle dictionnary for the map" + mapIndex + "is empty");
            return false;
        }

    }

    public Dictionary<Vector3, GameObject> GetLevelDictionary(int mapIndex)
    {
        if (obstaclesDictionary != null)
            obstaclesDictionary.Clear();

        try
        {

            obstaclePosition = DataContainer.singleton.metaData.DataList[mapIndex].arena.obstaclesPosition;
            obstacleObject = DataContainer.singleton.metaData.DataList[mapIndex].arena.obstaclesObject;

        }
        catch
        {
            Debug.LogError("Error in Data for obstacle position or obstacle position => obstacle Dictionarry empty");
        }

        

        for (int i = 0; i < obstaclePosition.Count; i++)
        {
            obstaclesDictionary.Add(obstaclePosition[i], obstacleObject[i]);
        }

        return obstaclesDictionary;

    }

    public void ExecuteDebug()
    {

        OnSetupTeam(new OnSetupTeamEventArg(new List<int> { 1 }, new List<int> { 12}));

        OnSetupMap(new OnSetupMapEventArg(obstaclesDictionary, 0, InstanciateMap(0)));

        OnMode(new OnModeEventArg(1));

    }

}

