using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Data/MetaData", order = 2)]
public class LevelMetaData : ScriptableObject
{
    [SerializeField]
    public List<DataArena> DataList;

    public List<GameObject> obstacles;

    public List<string> obstaclesName;

}
