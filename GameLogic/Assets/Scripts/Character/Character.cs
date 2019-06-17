using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Character : MonoBehaviour
{
    #region Settings
    public int index;
    public float maxHP;
    public string name, description;
    // List<Spells> Abilities;
    // List <Effect> Effects;
   public GameObject prefabCharacter;
    #endregion
    #region Events
    public class OnHpCheckEventArgs : EventArgs
    {
        public float HP;
    }
    public EventHandler<OnHpCheckEventArgs> onHpCheck;
    private void OnHpCheck(OnHpCheckEventArgs args)
    {
        if (onHpCheck != null)
            onHpCheck(this, args);
    }

    public class OnApCheckEventArgs : EventArgs
    {
        //recup AP restant dans script DataActionPoint
    }
    public EventHandler<OnApCheckEventArgs> onApCheck;
    private void OnApCheck(OnApCheckEventArgs args)
    {
        if (onApCheck != null)
            onApCheck(this, args);
    }

    public class OnSlowDownEventArgs : EventArgs
    {
        public float SpeedDown;
    }
    public EventHandler<OnSlowDownEventArgs> onSlowDown;

    private void OnSlowDown(OnSlowDownEventArgs args)
    {
        if (onSlowDown != null)
            onSlowDown(this, args);
    }

    public class OnDeathEventArgs : EventArgs
    {
		public int index;
    }
    public EventHandler<OnDeathEventArgs> onDeath;

    private void IsDead(OnDeathEventArgs args)
    {
        if (onDeath != null)
            onDeath(this, args);
    }

    #endregion
    #region Subscribe

    #endregion
}
