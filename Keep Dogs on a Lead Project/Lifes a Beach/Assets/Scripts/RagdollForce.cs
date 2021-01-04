using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollForce : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;

    public CharacterJoint cj;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cj = GetComponent<CharacterJoint>();
        rb.AddForce(-transform.up * 9000f);
        rb.AddForce(transform.forward * 9000f);



        //Invoke("DeleteSpine", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeleteSpine()
    {
        Destroy(cj);
    }
}
