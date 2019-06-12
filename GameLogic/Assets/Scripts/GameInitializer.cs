using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInitializer : MonoBehaviour
{
    private void Awake()
    {


        //Todo: FindObjectOfType<GameInitializer>().onMenu += OnMenuListernerHandler; 
        //Todo: Intercepté l event du Menu Start
    }
    public class ModeEventArg : EventArgs
    {
        public int Mode;

    }

    public class MapEventArg : EventArgs
    {
        public int Map;
    }


    public class UIEventArg
    {

    }

    public class TeamEventArg : EventArgs
    {
        public List<int> Team1;
        public List<int> Team2;
    }

    public EventHandler<ModeEventArg> onMode;
    public EventHandler<MapEventArg> onMap;
    public EventHandler<TeamEventArg> onTeam;
    public EventHandler<UIEventArg> onUI;



    private void OnMode(ModeEventArg e)
    {

        if (onMode != null)
        {
            onMode(this, e);
        }
    }

    private void OnMap(MapEventArg e)
    {

        if (onMap != null)
        {
            onMap(this, e);
        }
    }



    private void OnTeam(TeamEventArg e)
    {
        if (onTeam != null)
        {

            onTeam(this, e);
        }

    }

    private void Mode()
    {

        OnMode(new ModeEventArg() { });
    }

}
