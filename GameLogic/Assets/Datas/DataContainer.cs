using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour
{

    public static DataContainer singleton;

    public LevelMetaData metaData ;
    public DataArena dataArena;
  

    private void Awake()
    {

        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;

    }

}
