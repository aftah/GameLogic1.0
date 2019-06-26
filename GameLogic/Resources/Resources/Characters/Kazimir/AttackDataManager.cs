using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDataManager : MonoBehaviour
{
    public static AttackDataManager singleton;
    public DataAttack Attack1, Attack2, Attack3, Attack4, Attack5, Attack6, Attack7, Attack8, AttackPassive;
    public List<AttackModel> listForAttackLibrary;
    void Awake()
    {
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this;


    }

    public void AttacksAssembler()//groups the attacks in attack library
    {
        listForAttackLibrary.Add(AttackMaker(AttackPassive));// index pos 0
        listForAttackLibrary.Add(AttackMaker(Attack1)); // index pos 1
        listForAttackLibrary.Add(AttackMaker(Attack2)); // index pos 2,etc.
        listForAttackLibrary.Add(AttackMaker(Attack3));
        listForAttackLibrary.Add(AttackMaker(Attack4));
        listForAttackLibrary.Add(AttackMaker(Attack5));
        listForAttackLibrary.Add(AttackMaker(Attack6));
        listForAttackLibrary.Add(AttackMaker(Attack7));
        listForAttackLibrary.Add(AttackMaker(Attack8));
        //if you replace an attack by a custom one
        /*
         * listForAttackLibrary[numéro de l'attaque]=new Custom attack()
         */

    }
    public AttackModel AttackMaker(DataAttack da)//puts data in every attacks
    {
        return new AttackModel(da.AttackInfo.attackName,da.AttackInfo.damage,new Vector2(da.AttackInfo.distance,da.AttackInfo.distance),da.AttackInfo.zone,da.AttackInfo.cost);
    }
    public void EffectProvider()//adds an effect to an attack
    {

        // Ajout des effets, numéros d'index équivalent a celui de l'attaque sélectionnée. (point de vie, PA, mobilité, agilité, protection, nombre de tour  actif)
        listForAttackLibrary[1].AddEffect(new Effects(0, 4, 0, 0, 0, 1)); //ici retrait de 4PA.
        listForAttackLibrary[1].AddEffect(new Effects(- Attack1.AttackInfo.dot, 0, 0, 0, 0, 3)); // Poison qui dure 3 tours.

    }

    //Declare custom attacks here
    /*
     * 
     * public class CustomAttack : AttackModel
     * {
     * public CustomAttack()
     * {
     *  set here the values for your attack 
     * }
     * public override void AttackExecute()
     * {
     *   code how your attack works here
     * }
     * }
     */
}
