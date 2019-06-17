using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChoiceManager : MonoBehaviour
{
    public void ChangeChoice(int Choice)
    { 
        OnChoiceChange(new OnChoiceChangeEventArgs() { Choice = Choice });

    }

    public class OnChoiceChangeEventArgs : EventArgs
    {

        public int Choice;
    }

    public event EventHandler<OnChoiceChangeEventArgs> onChoiceChange;

    public void OnChoiceChange(OnChoiceChangeEventArgs e)
    {
        onChoiceChange?.Invoke(this, e);
    }
}
