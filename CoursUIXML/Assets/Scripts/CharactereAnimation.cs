using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactereAnimation : MonoBehaviour
{
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("X",Input.GetKey(KeyCode.RightArrow) ? 1 : 0);
        if (Input.GetKeyDown(KeyCode.Space ))
        {
            animator.SetBool("RunBool", true); 
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("RunBool", false);
        }
    }
}
