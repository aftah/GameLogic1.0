using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurByakko : Character
{
    // Classe exemple de personnage. Créé une classe pour votre personnage en copiant celle-ci. 
    private void Awake()
    {
        // Les HP, Ap, l'agilité, le tacle, la mobilité et le shield de votre personnages, sont à set dans votre Data.
        
        // pas toucher 😠
        currentHP = CharacterDataContainer.singleton.testCharacter.characterTest.HPMax;
        // Nom du personnage
        name = "Byakko";
        // Class du perso choisir entre: "Warrior", "Mage", "Rogue"
        type = "Warrior";
        // pas toucher(non plus) 😠
        currentAp = CharacterDataContainer.singleton.globalAP.apInfo.maxAp;
        currentAgility = CharacterDataContainer.singleton.testCharacter.characterTest.defaultAgility;
        currentTackle = CharacterDataContainer.singleton.testCharacter.characterTest.defaultTackle;
        currentMobility =CharacterDataContainer.singleton.testCharacter.characterTest.defaultMobility;
        currentShield= CharacterDataContainer.singleton.testCharacter.characterTest.minShield;

        // Numéros d'index a associer a votre personnage. Un numéros d'index unique par personnage, de 1 à 13.
        indexPlayer = 0;

        

        //  GetAttacks();
        //    attackLibrary[1].AddEffectToAttack(new Effects());
        //CharacterLibrary.characterList.Add(gameObject);
    }

    //overload the GetAttacks method
    // Ajouter ici vos sorts selon le modèle ci-dessous
    public override void GetAttacks()
    {
        //// ("index du sort", dégats, portée du sort, zone d'effet du sort, cooldown, cout en AP)
        
   
       
        Effects tryEffect = new Effects(50,2);
  
    }

}

