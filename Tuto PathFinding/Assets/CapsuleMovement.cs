using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float speed = 2000f;
    [SerializeField]
    private float min = 1f;
    [SerializeField]
    private float max = 1f,dir;
    [SerializeField]
    private bool lr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 move = new Vector3(Random.Range(-min, max), 0, 0);
        rb.AddForce(move * speed);
        dir = move.x;
        lr = true;
    }

    private void FixedUpdate()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall"  )
        {
            if (lr) { dir *= -1; } else { dir *= 1; }
            rb.velocity = Vector3.zero;
            lr = !lr;
            rb.AddForce( new Vector3(dir,0,0)*speed);

        }
    }
}
