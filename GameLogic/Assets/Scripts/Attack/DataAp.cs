using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "DataAp", menuName = "Data/AP", order = 0)]
public class DataAp : ScriptableObject
{
        [System.Serializable]
        public class APData
        {
            public int maxAp;

        }
        public APData apInfo;
}