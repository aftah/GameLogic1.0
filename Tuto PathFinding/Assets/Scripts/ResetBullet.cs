using UnityEngine;

public class ResetBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            this.transform.gameObject.SetActive(false);
        }
    }
}
