using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Arena", order = 3)]
public class DataArena : ScriptableObject
{

    [System.Serializable]
    public class Arena
    {
        public List<Vector3> obstaclesPosition = new List<Vector3>();
        public List<GameObject> obstaclesObject = new List<GameObject>();
    }

    public List<Vector3> GetPosition()
    {
        return arena.obstaclesPosition;
    }

    public List<GameObject> GetGameObject()
    {
        return arena.obstaclesObject;
    }

    [SerializeField]
    public Arena arena;



}
