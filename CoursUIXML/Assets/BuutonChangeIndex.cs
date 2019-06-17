using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuutonChangeIndex : MonoBehaviour
{
    [SerializeField]
    private int index;

    public void Onclick()
    {

        FindObjectOfType<ChoiceManager>().ChangeChoice(index); 
    }
}
