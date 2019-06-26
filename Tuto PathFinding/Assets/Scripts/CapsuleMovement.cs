using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    private float speed = 2000f;
    [SerializeField]
    private float min = 1f;
    [SerializeField]
    private float max = 1f;

    private float direction;
   
    private bool leftOrRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 move = new Vector3(Random.Range(-min, max), 0, 0);
        rb.AddForce(move * speed);
        direction = move.x;
        leftOrRight = true;
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall"  )
        {
            if (leftOrRight) { direction *= -1; } else { direction *= 1; }
            rb.velocity = Vector3.zero;
            leftOrRight = !leftOrRight;
            rb.AddForce( new Vector3(direction, 0,0) * speed);

        }
    }
}
