using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoverPath : MonoBehaviour
{
    
    Transform target;
    public GameManager gameManager;
    public NavMeshAgent agent;
    public Transform[] destinationPoints;

    public int destinationIndex = 0;

    public bool iSeeYou;

    private float nextTime;
    private float totalTime;

    private bool wait;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        iSeeYou = false;
    }

    void Update()
    {
        /*if (Time.time > nextTime)
        {

            if(iSeeYou == true)
            { 
                TimerFollow();
            }
        }*/

        if(Vector3.Distance(transform.position, target.position) < 10f)
        {
            //agent.destination = target.position;
            iSeeYou = true;

            if (Time.time > nextTime)
            {

                if(iSeeYou == true)
                { 
                    TimerFollow();
                }
            }
        }
        else
        {
            iSeeYou = false;
        }

        if(iSeeYou)
        {
            agent.destination = target.position;
        }
        else
        {
            if(wait==false){
                //va a la posicion de patrulla actual
                agent.destination = destinationPoints[destinationIndex].position;

                if(Vector3.Distance(transform.position, destinationPoints[destinationIndex].position)<3f)
                {
                    
                    destinationIndex=Random.Range(0, 4);
                    
                    StartCoroutine(Wait());
                }
            }
        }
    }

    private void TimerFollow()
    {
        if(gameManager.isPlaying == true)
        {
            
            if(totalTime >= 0)
            {
                totalTime -= Time.deltaTime;
            }
            
            if (totalTime < 0)
            {      
                totalTime = 0;
                iSeeYou=false;
                totalTime = 10;
            }

        }
    }

    public IEnumerator Wait()
    {
        wait=true;
        yield return new WaitForSeconds(1);
        wait=false;
    }
}
