using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LangueManager : MonoBehaviour
{
   

    public void ChangeLangue(string langue)
    {

        OnLangueChange(new OnLangueChangeEventArgs() { langue = langue }); 

    }

    public class OnLangueChangeEventArgs : EventArgs
    {

        public string langue;
    }

    public event EventHandler<OnLangueChangeEventArgs> onLangueChange;

    public void OnLangueChange(OnLangueChangeEventArgs e)
    {
        onLangueChange?.Invoke(this, e);
    }


}
