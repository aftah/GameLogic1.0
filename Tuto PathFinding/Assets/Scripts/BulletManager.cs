using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    List<GameObject> poolListGameObject;

    static BulletManager _instanceBulletManager;

    public static BulletManager InstanceBulletManager
    {
        get
        {
            if (_instanceBulletManager == null)
            { 
                _instanceBulletManager = FindObjectOfType<BulletManager>() ;
            }
            return _instanceBulletManager;
        }
    }

    private void OnEnable()
    {
        poolListGameObject = new List<GameObject>();
    }

    public void CreatePool(GameObject prefab,int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab) as GameObject ;
            obj.SetActive(false);
            poolListGameObject.Add(obj);
        }
        
    }

    public void ReUseObject(GameObject prefab,Vector3 position,Quaternion rotation)
    {
        Rigidbody rb;
        for (int i = 0; i < poolListGameObject.Count  ; i++)
        {
            if (!poolListGameObject[i].activeInHierarchy  )
            {
                poolListGameObject[i].transform.position = position;
                poolListGameObject[i].transform.rotation  = rotation ;
                poolListGameObject[i].SetActive(true);
                rb = poolListGameObject[i].GetComponent<Rigidbody>();
                rb.velocity = rb.transform.forward    * 200f;
                break;
            }
        }
    }
   
}
