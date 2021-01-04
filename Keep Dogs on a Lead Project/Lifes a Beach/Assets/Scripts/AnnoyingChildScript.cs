using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnnoyingChildScript : MonoBehaviour
{

    private GameObject Player;
    private GameObject Dog;

    NavMeshAgent Enemy;

    private GameObject body;

    private GameObject fallenOver;

    public bool gotDog;

    public Movement movementScript;

    public GameObject spot;

    public float distance = 0f;

    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
        Dog = GameObject.FindGameObjectWithTag("Dog");
        Player = GameObject.FindGameObjectWithTag("Player");

        body = this.gameObject.transform.GetChild(0).gameObject;
      
        fallenOver = this.gameObject.transform.GetChild(1).gameObject;

        movementScript = Player.GetComponent<Movement>();
    }


    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, Dog.transform.position);
        if(!gotDog)
        {
            Enemy.SetDestination(Dog.transform.position);
        }
        else
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;

            Enemy.SetDestination(newPos);
            Dog.transform.position = spot.transform.position;

            if(distance > 11.0f)
            {
                Enemy.speed = 0f;
                //drag player
                movementScript.DraggedByKid();
            }
            else if (distance > 10)
            {
                Enemy.speed = 0.5f;
            }
            else if (distance > 9)
            {
                Enemy.speed = 2.0f;
            }
            else if (distance > 7)
            {
                Enemy.speed = 3.0f;
            }
            else
            {
                Enemy.speed = 3.5f;
            }


        }
        
    }

    

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
    }



    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            // player smacks 
            if(gotDog == true)
            {
                gotDog = false;
                movementScript.dogTaken = false;
                Dog.transform.position = new Vector3(Dog.transform.position.x, 0.3f, Dog.transform.position.z);
            }
            
            transform.DetachChildren();
            fallenOver.SetActive(true);
            Destroy(body);
            Destroy(this.gameObject);

        }
        else if (other.gameObject.tag == "Dog")
        {
            // grabbed dog 
            gotDog = true;
            movementScript.dogTaken = true;

        }
    }

}



