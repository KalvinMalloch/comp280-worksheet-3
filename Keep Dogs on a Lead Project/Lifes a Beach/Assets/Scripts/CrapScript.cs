using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrapScript : MonoBehaviour
{

    private GameObject Player;
    private GameObject Dog;

    NavMeshAgent Enemy;

    private GameObject body;


    public bool pinchedHuman;

    public bool scaredByDog;

    public Movement movementScript;

    // public float distance = 0f;
    private Animator anim2;

    public GameObject hide;

    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        Dog = GameObject.FindGameObjectWithTag("Dog");
        Player = GameObject.FindGameObjectWithTag("Player");

        body = this.gameObject.transform.GetChild(0).gameObject;
        hide = this.gameObject.transform.GetChild(1).gameObject;
        movementScript = Player.GetComponent<Movement>();

        anim2 = body.GetComponent<Animator>();
    }


    void Update()
    {
    
        if(!pinchedHuman && !scaredByDog)
        {
            Enemy.SetDestination(Player.transform.position);
        }

        if(scaredByDog)
        {
            Vector3 dirToPlayer = transform.position - Dog.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;

            Enemy.SetDestination(newPos);
        }

        


    }

    

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        pinchedHuman = false;
        anim2.Play("Walk2");
        if(scaredByDog == true)
        {
            Enemy.speed = 4.5f;
        }
        else
        {
            Enemy.speed = 2.0f;
        }
        
    }

    IEnumerator HideDelay()
    {
        yield return new WaitForSeconds(10f);
        body.SetActive(false);
        hide.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);


    }



    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if(!pinchedHuman && !scaredByDog)
            {
                Enemy.speed = 0.0f;
                movementScript.CrabPinched();
                pinchedHuman = true;
                anim2.Play("Attack2");
                StartCoroutine(Delay());
            }
            

        }
        else if (other.gameObject.tag == "Dog")
        {
            // stomped by dog

            //transform.DetachChildren();
            //Destroy(body);

            //Destroy(this.gameObject);

            scaredByDog = true;
            if(anim2 != null)
            {
                anim2.Play("Walk2");
            }

            
            Enemy.speed = 4.5f;
            StartCoroutine(HideDelay());




        }
    }

}



