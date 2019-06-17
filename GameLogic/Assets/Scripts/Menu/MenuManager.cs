using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MenuManager : MonoBehaviour
{
    // onmenuinitiallise  onmodechoose onmapchoose oncharactervalidate onteamchoose

    private int mapIndex;
    private List<int> charactersPlayer1, characterPlayer2;

    private void Awake()
    {
        FindObjectOfType<ModePanelScript>().onModeSelectedEventHandler += OnmodeSelectEventHandler;
    }

    private void OnmodeSelectEventHandler(object sender, ModePanelScript.OnModeSelectedEventArgs e)
    {
        
    }

    private void Start()
    {
        charactersPlayer1 = new List<int>();
        charactersPlayer1 = new List<int>();
        mapIndex = 0;
    }
    public class OnGameInitializeEventArgs : EventArgs   // send to listner in to init the game in GameInitializer
    {
        public int mapIndex;
        public List<int> charactersPlayer1;
        public List<int> charactersPlayer2;
    }

    public class OnMenuInitialliseEventArgs : EventArgs
    {
        public int menuPanel;
    }
    public class OnModeChooseEventArgs : EventArgs
    {
        public int mode;
    }
    public class OnMapChooseEventArgs : EventArgs
    {
        public int map;
    }
    public class OnCharacterValidateEventArgs : EventArgs
    {
        public int character;
    }

    public class OnTeamChooseEventArgs : EventArgs
    {
        public bool team;
    }

    // init the events

    public event  EventHandler<OnMenuInitialliseEventArgs> onMenuInit;
    public event EventHandler<OnModeChooseEventArgs> onModeChooseEventHandler;
    public event  EventHandler<OnMapChooseEventArgs> onMapChoose;
    public event EventHandler<OnCharacterValidateEventArgs> onCharacterValidateEventHandler;
    public event  EventHandler<OnTeamChooseEventArgs> onTeamChoose;
    public event EventHandler<OnGameInitializeEventArgs> onGameInitialise;
    // private functions
    private void OnGameInitialize(OnGameInitializeEventArgs args)
    {
        if (onGameInitialise != null) { onGameInitialise(this, args); }
    }
    private void OnMenuInitEvent(OnMenuInitialliseEventArgs args)
    {
        if(onMenuInit != null) { onMenuInit(this, args); }
    }
    private void OnModeChooseEvent(OnModeChooseEventArgs args)
    {
        if(onModeChooseEventHandler != null) { onModeChooseEventHandler(this, args); }
    }

    private void OnMapChooseEvent(OnMapChooseEventArgs args)
    {
        if (onMapChoose != null) { onMapChoose(this, args); }
    }
    private void OnCharacterValidateEvent(OnCharacterValidateEventArgs args)
    {
        if (onCharacterValidateEventHandler != null) { onCharacterValidateEventHandler(this, args); }
    }
    private void OnTeamChooseEvent(OnTeamChooseEventArgs args)
    {
        if (onTeamChoose != null) { onTeamChoose(this, args); }
    }

    private void InitLevel()
    {

    }

}
