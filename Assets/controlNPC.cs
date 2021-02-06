using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlNPC : MonoBehaviour
{
    public Animator animator;
    // public Vector3 target;
    public bool isWalking = false;
    public int waitingCounter = 800;
    public UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      // UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>()
      // animator.SetTrigger("walk");
      animator.SetTrigger("walk");
      agent.destination = new Vector3(transform.position.x + Random.Range(-50, 50), 0, transform.position.z + Random.Range(-50, 50));
      isWalking = true;
    }

    // Update is called once per frame
    void Update()
    {
      if(waitingCounter < 800){
        waitingCounter += 1;
        return;
      }

      if(waitingCounter == 800 && !isWalking){
        animator.SetTrigger("walk");
        agent.destination = new Vector3(transform.position.x + Random.Range(-20, 20), 0, transform.position.z + Random.Range(-20, 20));
        isWalking = true;
      }

      if(agent.remainingDistance == 0 && isWalking){
        isWalking = false;
        waitingCounter = 0;
        animator.SetTrigger("walk");
      }


    }

}
