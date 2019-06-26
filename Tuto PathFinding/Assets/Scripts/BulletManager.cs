using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int spawnNbr=10;
    [SerializeField]
    private List<GameObject> _bulletListForPool = new List<GameObject>();

    public List<GameObject> BulletList
    {
        get { return _bulletListForPool; }

    }

    private void Start()
    {
        GameObject prefabBullet;
        for (int i = 0; i < spawnNbr ; i++)
        {
            prefabBullet = Instantiate(bulletPrefab) as GameObject ;
            _bulletListForPool.Add(prefabBullet);
            prefabBullet.transform.parent  = this.transform;
            prefabBullet.SetActive(false); 
        }
    }

   
}
