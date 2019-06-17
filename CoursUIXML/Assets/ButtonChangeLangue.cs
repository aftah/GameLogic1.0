using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeLangue : MonoBehaviour
{
    [SerializeField]
    private string langue;

    public void OnClick()

    {
        FindObjectOfType<LangueManager>().ChangeLangue(langue);
    }
}
