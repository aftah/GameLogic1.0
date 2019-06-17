using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //Creation des Map
    
   
    private void Awake()
    {
      
       
    }

    public class OnMapEventArg : EventArgs 
    {
    }
    public event EventHandler<OnMapEventArg> onMap;

    private void OnMap(OnMapEventArg e)
    {

        if (onMap != null)
        {
            onMap(this, e);
        }
    }

}

