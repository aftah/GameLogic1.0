using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DataCharacter", menuName = "Data/Character", order = 0)]
public class DataCharacter : ScriptableObject
{
    // Data exemple pour les personnages. Vous pouvez set les HP de votre personnage ici. 
    // Ajouter votre Data dans le dataContainer.
    [System.Serializable]
    public class CharacterTest
    {
        // point de vie, moyenne: 100
        public float HPMax=100;
        //shield starts at 0
        public float minShield=0;
        public int defaultAgility=5;
        // Tacle en %, de 0 à 100
        public int defaultTackle=5;
        // Mobilité de 0 à 10
        public int defaultMobility=5;

    }
    public CharacterTest characterTest;
}
