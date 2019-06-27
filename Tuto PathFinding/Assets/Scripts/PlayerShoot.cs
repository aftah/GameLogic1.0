using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;
    private float counter=0;
    private float delaytime = 2f;

    private void OnEnable()
    {
        FindObjectOfType<InputManager>().onKeyPressedEventHandler += PlayerShoot_onKeyPressedEventHandler;
    }


    private void PlayerShoot_onKeyPressedEventHandler(object sender, OnKeyPressedEvenArgs e) 
    {
        if(e.Shoot ==true && counter>delaytime )
        { 
            Shoot();
           
        }
        counter += Time.deltaTime; 
            
    }

    // Start is called before the first frame update
    void Start()
    {
        BulletManager.InstanceBulletManager.CreatePool(prefabBullet, 10);  
    }

    // Update is called once per frame
   

    public void Shoot()
    {
       
       
           
            BulletManager.InstanceBulletManager.ReUseObject(prefabBullet, transform.position, Quaternion.identity);
       
        
        

    }
}
