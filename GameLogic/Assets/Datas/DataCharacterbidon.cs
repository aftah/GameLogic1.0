using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CreateAssetMenu qui permet de créer cet objet depuis le menu dans l'inspector
[CreateAssetMenu(fileName = "Data", menuName = "Data/Character", order = 0)]
public class DataCharacterbidon : ScriptableObject
{
   
        [SerializeField ]    
        public GameObject []  listPrefabCharactere;
       

}
