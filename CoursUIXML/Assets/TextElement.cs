using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextElement : MonoBehaviour
{
    [SerializeField]
    int index;
    [SerializeField]
    XMLReader.EComponent component;
    private string langue = "FR";

    [SerializeField]
    private bool isChange;
    private Text text;

    private void Awake()
    {
        FindObjectOfType<LangueManager>().onLangueChange += OnChangementLangueEventHandler;
        FindObjectOfType<ChoiceManager>().onChoiceChange += OnChangementIndexEventHandler;
        text = GetComponent<Text>();
        UpdateText();
       
    }

    private void OnChangementIndexEventHandler(object sender, ChoiceManager.OnChoiceChangeEventArgs  e)
    {
        if (!isChange)
            return;
        index = e.Choice ;
        UpdateText(); 
    }

    private void OnChangementIndex()
    {

    }

    private void OnChangementLangueEventHandler(object sender, LangueManager.OnLangueChangeEventArgs e )
    {

        langue = e.langue;
        UpdateText(); 
    }

    private void UpdateText()
    {
      text.text =  XMLReader.GetTextInfo(langue, index, component); 
    }

}
