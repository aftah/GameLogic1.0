using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Effects : MonoBehaviour
{
    public string nameEffect;
    public int HP, AP, mobility, agility, shield, counter;
    public Vector2 position, destination;
    int timer_;
    private void Awake()
    {
        timer = counter;
    }
    public int timer
    {
        get { return timer_; }
        set { timer_ = value; }
    }
    public Effects( int LP,int duration)
    {
        HP = LP;
        counter = duration;
    }
    public virtual void ExecuteEffect(int index)
    {
        
    }

}

