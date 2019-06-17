using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDictionary : MonoBehaviour
{

    public Dictionary<Vector3, GameObject> obstaclesDictionary;

    private List<Vector3> obstaclePosition;
    private List<GameObject> obstacleObject;

    public class ObstacleDictionaryEventArgs : EventArgs
    {
        public Dictionary<Vector3, GameObject> obstaclesDictionary = new Dictionary<Vector3, GameObject>();
    }

    public event EventHandler<ObstacleDictionaryEventArgs> onLoadArena;

    public void OnLoadArena(ObstacleDictionaryEventArgs e)
    {
        onLoadArena?.Invoke(this, e);
    }

    public void OnLoadArenaEventHandler(object sender, ObstacleDictionaryEventArgs e)
    {
        OnLoadArena(new ObstacleDictionaryEventArgs() { obstaclesDictionary = GetLevelDictionary(0) });
    }
    private void Awake()
    {

    }

    public Dictionary<Vector3, GameObject> GetLevelDictionary(int arenaIndex)
    {
        if(obstaclesDictionary != null)
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

    public void ShowDico()
    {

        Dictionary<Vector3, GameObject> mondico = GetLevelDictionary(0);

        foreach (var item in mondico)
        {
            Instantiate(item.Value, item.Key, item.Value.transform.rotation);
        }

        foreach (var item in mondico)
        {
            Debug.Log(item.Key);
            Debug.Log(item.Value);
        }
    }

}
