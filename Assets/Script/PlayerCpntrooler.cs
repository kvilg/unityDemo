using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCpntrooler : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;

    public float rotationSpeed = 10;
    public float speed = 2f;
    
    void Start()
    {
        animator  = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3(-v,0,h);
        if(directionVector.magnitude > Mathf.Abs(0.05f)){
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(directionVector), Time.deltaTime * rotationSpeed);
        }
        animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector,1).magnitude);
        rigidbody.velocity = Vector3.ClampMagnitude(directionVector,1) * speed;

        
    }
}
