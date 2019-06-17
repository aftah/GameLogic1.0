using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ModePanelScript : MonoBehaviour
{
	[SerializeField]
	private GameObject panel;
    private void Awake()
    {
		MenuManager menuManager = FindObjectOfType<MenuManager>();
		menuManager.onMenuInit += OnMenuInitListener;
		menuManager.onModeChooseEventHandler += OnModeChooseListener;
	}

	private void OnModeChooseListener(object sender, MenuManager.OnModeChooseEventArgs e)
	{
		panel.SetActive(false);
	}

	private void OnMenuInitListener(object sender, MenuManager.OnMenuInitialliseEventArgs e)
    {
		panel.SetActive(true);
    }
    public class OnModeSelectedEventArgs : EventArgs
    {
        public int numberOfCharacters;
    }

    public EventHandler<OnModeSelectedEventArgs> onModeSelectedEventHandler;


    private void OnModeSelected(OnModeSelectedEventArgs args)
    {
        if (onModeSelectedEventHandler != null) { onModeSelectedEventHandler(this, args); }
    }
}
