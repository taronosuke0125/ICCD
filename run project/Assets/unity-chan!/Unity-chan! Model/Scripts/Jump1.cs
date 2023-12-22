using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump1 : MonoBehaviour
{
    private const float _velocity = 5.0f;
    private Rigidbody _rigidbody;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isGrounded = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                Vector3 jump_vector = Vector3.up;
                Vector3 jump_velocity = jump_vector*_velocity;
                _rigidbody.velocity = jump_velocity;
                _isGrounded = false;
            }
        }
    }

    void OncollisionEnter(Collision other)
    {
        _isGrounded = true;
    }
}
