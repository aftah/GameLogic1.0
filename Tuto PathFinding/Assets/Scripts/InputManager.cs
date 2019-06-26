using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{

    public event EventHandler<OnKeyPressedEvenArgs> onKeyPressedEventHandler;

    private void OnKeyPressed(OnKeyPressedEvenArgs e)
    {
        onKeyPressedEventHandler?.Invoke(this, e); 

    }

    
    private void Update()
    {
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);

        bool shoot = Input.GetKey(KeyCode.Space);

        if (left == true || right == true || up == true || down == true)
        {
            OnKeyPressed(new OnKeyPressedEvenArgs(new Vector3(left ? -1 : 0, right ? 1 : 0,0),new Vector3(up ? 0 :-1,down ? 0 : 1)));
        }

        if (shoot == true)
        {
            OnKeyPressed(new OnKeyPressedEvenArgs(true));
        }

        
    }

}

public class OnKeyPressedEvenArgs
{
    private Vector3 _horizontal;
    private Vector3 _vertical;
    private bool _shoot;

    public bool Shoot
    {
        get { return _shoot; }
        private set { value = _shoot; }
    }


    public Vector3 Horizontal 
    {
        get { return _horizontal; }
        private set { value = _horizontal; }
    }

    public Vector3 Vertical
    {
        get { return _vertical; }
        private set { value = _vertical; }
    }

    public OnKeyPressedEvenArgs(Vector3 horizontal,Vector3 vertical)
    {
        _horizontal = horizontal;
        _vertical = vertical;
    }

    public OnKeyPressedEvenArgs(bool shoot)
    {
        _shoot = shoot;
    }

   

}

