using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private BulletManager _bulletPool;

    private void OnEnable()
    {
        FindObjectOfType<InputManager>().onKeyPressedEventHandler += PlayerShoot_onKeyPressedEventHandler;
    }


    private void PlayerShoot_onKeyPressedEventHandler(object sender, OnKeyPressedEvenArgs e) 
    {
        if(e.Shoot ==true)
            Shoot();
    }

    // Start is called before the first frame update
    void Start()
    {
        _bulletPool = GetComponent<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {

        for (int i = 0; i < _bulletPool.BulletList.Count; i++)
        {
            if (_bulletPool.BulletList[i].activeInHierarchy == false )
            {
                _bulletPool.BulletList[i].SetActive(true);
                _bulletPool.BulletList[i].transform.Translate(Vector3.down * Time.deltaTime);
                
                break;
            }
        }

    }
}
