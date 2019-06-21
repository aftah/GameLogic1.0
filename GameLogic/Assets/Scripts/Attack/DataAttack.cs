using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataAttack", menuName = "Data/Attack", order = 2)]
public class DataAttack : ScriptableObject
{
    [System.Serializable]
    public class AttackData
    {
        public int damage;

    }
    public AttackData AttackInfo;
}