using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsPlayer : MonoBehaviour
{

    private bool isMoving;
    private Vector3 playerMovement;

    private void Awake()
    {
        FindObjectOfType<MovementsManager>().onMovementPlayer += OnMovementPlayerEventHandler;
    }

    public class OnStoppedMovingEventArgs : EventArgs
    {
    }

    public event EventHandler<OnStoppedMovingEventArgs> onStoppedMovingEvent;

    public void OnStoppedMovingEvent(OnStoppedMovingEventArgs e)
    {
        if (onStoppedMovingEvent != null)
            onStoppedMovingEvent(this, e);
    }

    public void OnStoppedMovingEventHandler()
    {
        OnStoppedMovingEvent(new OnStoppedMovingEventArgs() { });
    }


    private void OnMovementPlayerEventHandler(object sender, MovementsManager.OnMovementsPlayerEventArgs e)
    {
        isMoving = true;      
        // On bouge notre cul sa daronne;
        //OnStoppedMovingEventHandler();
    }

}
