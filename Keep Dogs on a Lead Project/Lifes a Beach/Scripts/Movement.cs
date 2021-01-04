using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody man;
    public Rigidbody dog;
    public float manSpeed;
    public float dogSpeed;
    public float leadLength;
    float coolDown;

    void Start()
    {
        man = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //Manly Movement
        if (Input.GetKey(KeyCode.W))
        {
            man.transform.eulerAngles = new Vector3(0, 0, 0);
            man.velocity = (Vector3.forward * manSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            man.transform.eulerAngles = new Vector3(0, 180, 0);
            man.velocity = (Vector3.back * manSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            man.transform.eulerAngles = new Vector3(0, 90, 0);
            man.velocity = (Vector3.right * manSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            man.transform.eulerAngles = new Vector3(0, 270, 0);
            man.velocity = (Vector3.left * manSpeed);
        }



        //Dogo Movement
        coolDown -= Time.deltaTime;

        if (Vector3.Distance(man.transform.position, dog.transform.position) < leadLength && coolDown < 0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                dog.transform.eulerAngles = new Vector3(0, 0, 0);
                dog.velocity = (Vector3.forward * dogSpeed);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                dog.transform.eulerAngles = new Vector3(0, 180, 0);
                dog.velocity = (Vector3.back * dogSpeed);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                dog.transform.eulerAngles = new Vector3(0, 90, 0);
                dog.velocity = (Vector3.right * dogSpeed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                dog.transform.eulerAngles = new Vector3(0, 270, 0);
                dog.velocity = (Vector3.left * dogSpeed);
            }
        }

        else
        {            
            dog.transform.LookAt(new Vector3(man.transform.position.x, dog.transform.position.y, man.transform.position.z));
            dog.velocity = (dog.transform.forward * dogSpeed);
        }

        if (Vector3.Distance(man.transform.position, dog.transform.position) > leadLength)
        {
            coolDown = 0.2f;
        }
    }
}
