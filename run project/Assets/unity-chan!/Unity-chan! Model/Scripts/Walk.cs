using UnityEngine;
using System.Collections;

public class Walk : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKey("up"))
        {
            transform.position += transform.forward * 0.05f;
            animator.SetBool("is_running",true);
        }
        else if(Input.GetKey("down"))
        {
            transform.position -= transform.forward * 0.05f;
            animator.SetBool("is_running",true);
        }
        else 
        {
            animator.SetBool("is_running",false);
          
        }

        if(Input.GetKey("right"))
        {
            transform.Rotate(0,0.5f,0);
        }
        if(Input.GetKey("left"))
        {
            transform.Rotate(0,-0.5f,0);
        }
    }
}