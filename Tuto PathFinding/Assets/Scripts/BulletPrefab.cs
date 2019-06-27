using UnityEngine;

public class BulletPrefab : MonoBehaviour
{

  
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //his.transform.gameObject.SetActive(false);
            gameObject.SetActive(false);  
        }
    }

   
}
