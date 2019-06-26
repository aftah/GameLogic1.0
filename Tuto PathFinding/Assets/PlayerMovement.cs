using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private float _speed;

    public float Speed
    {
        get { return _speed; }

        private set { value = _speed; }
    }

    private void Awake()
    {
        _speed = 10.0f;
    }
    public event EventHandler<OnMovedEventArgs> onMovedEventHandler;

    private void OnMovedEventHandler(OnMovedEventArgs e)
    {

        onMovedEventHandler?.Invoke(this, e);  
    }

    private void OnEnable()
    {
        FindObjectOfType<InputManager>().onKeyPressedEventHandler += PlayerMovement_onKeyPressedEventHandler;
    }

    private void PlayerMovement_onKeyPressedEventHandler(object sender, OnKeyPressedEvenArgs e)
    {

        OnMovedEventHandler(new OnMovedEventArgs(transform.position, e.Horizontal));
        transform.Translate(new Vector3(e.Horizontal.x * Time.deltaTime * this.Speed , 0, 0));
        transform.Translate(new Vector3(e.Horizontal.y * Time.deltaTime * this.Speed, 0, 0));
        transform.Translate(new Vector3(0, 0, e.Vertical.x * Time.deltaTime * this.Speed ));
        transform.Translate(new Vector3(0, 0, e.Vertical.y * Time.deltaTime * this.Speed ));
    }

    private void OnDisable()
    {
        if(FindObjectOfType<InputManager>() != null)
            FindObjectOfType<InputManager>().onKeyPressedEventHandler -= PlayerMovement_onKeyPressedEventHandler;
    }

    
}

public class OnMovedEventArgs
{
    private Vector3  _playerPosition;
    private Vector3 _playerDirection;
  

    public Vector3 PlayerPosition
    {
        get { return _playerPosition; }

        private set { value = _playerPosition; }
    }
    public Vector3 PlayerDirection
    {
        get { return _playerDirection; }

        private set { value = _playerDirection; }
    }

   

    public OnMovedEventArgs(Vector3 playerPosition,Vector3 playerDirection)
    {
        _playerPosition = playerPosition;
        _playerDirection = playerDirection;
        
    }
}