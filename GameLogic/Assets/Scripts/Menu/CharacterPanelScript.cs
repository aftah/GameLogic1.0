using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterPanelScript : MonoBehaviour
{
	[SerializeField]
	private GameObject panel;
    private void Awake()
    {
		MenuManager menuManager = FindObjectOfType<MenuManager>();
		menuManager.onMapChoose += OnMapChooseEventHandler;
		menuManager.onTeamChoose += OnTeamChooseEventHandler;
	}

	private void OnTeamChooseEventHandler(object sender, MenuManager.OnTeamChooseEventArgs e)
	{
		panel.SetActive(false);
	}

	private void OnMapChooseEventHandler(object sender, MenuManager.OnMapChooseEventArgs e)
    {
        panel.SetActive(true);
    }


    public class OnCharactersSelectedEventArgs : EventArgs
    {
        public List<int> player1Characters;
        public List<int> player2Characters;
    }

    public event EventHandler<OnCharactersSelectedEventArgs> onCharactersSelectedEventHandler;

    private void OnCharacterSelected(OnCharactersSelectedEventArgs args)
    {
        if (onCharactersSelectedEventHandler != null) { onCharactersSelectedEventHandler(this, args); }
    }







}

