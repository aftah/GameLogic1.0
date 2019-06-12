using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //Creation Variables

    private void Awake()
    {
        FindObjectOfType<GameInitializer>().onMode += OnModeListenerHandler;

    }
    public class StartEventArg : EventArgs 
    {
    }

    public class StopEventArg : EventArgs 
    {
    }

    public class CharacterEventArg : EventArgs
    {


    }
    public class PositionEventArg : EventArgs 
    {
    }

    public EventHandler<StartEventArg> onStart;
    public EventHandler<StopEventArg> onStop;
    public EventHandler<CharacterEventArg> onCharacter;
    public EventHandler<PositionEventArg> onPosition;

   

    private void OnModeListenerHandler(object sender, GameInitializer.ModeEventArg e)
    {
        //initialisation du mode de jeux
    }

    private void OnStart(StartEventArg e)
    {
        if (onStart != null)
        {
            onStart(this, e);
        }
    }

    private void OnStop(StopEventArg e)
    {
        if (onStop != null)
        {
            onStop(this, e);
        }
    }
    private void OnCharacter(CharacterEventArg e)
    {

        if (onCharacter != null)
        {
            onCharacter(this, e);
        }
    }

    private void OnPosition(PositionEventArg e)
    {

        if(onPosition != null)
        {
            onPosition(this, e);
        }
    }
}

