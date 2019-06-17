using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleReference : MonoBehaviour
{

    public string objectName;
    string[] objectChars;

    private void Awake()
    {
        objectName = gameObject.name;
        
        try
        {
            objectName = objectName.Split(' ')[0];
            objectName = objectName.Split('(')[0];
        }

        catch (System.Exception)
        {
            objectName = gameObject.name;    
        }
        

    }

}
