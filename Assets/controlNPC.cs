using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlNPC : MonoBehaviour
{
    public Animator animator;

    // public bool isWalking = false;
    // public int waitingCounter = 500;
    public Vector3 center;
    public UnityEngine.AI.NavMeshAgent agent;
    public float wanderTimer;
    private float timer;
    public Rigidbody player;
    public Rigidbody npc;

    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
      IdleWalk();
    }

    public void IdleWalk(){
      float dist = Vector3.Distance(player.position, transform.position);
      if(dist< 4){
        Debug.Log(dist);
        animator.SetBool("walk", false);
        agent.SetDestination(npc.position);
        timer = wanderTimer;
        return;
      }

      timer += Time.deltaTime;

      if (timer >= wanderTimer) {
        Vector3 newPos = GetRandomPoint(center, 50f);
        agent.SetDestination(newPos);
        timer = 0;
      }

      if(agent.remainingDistance == 0){
        animator.SetBool("walk", false);
      }else{
        animator.SetBool("walk", true);
      }
    }

    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance) {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;
        UnityEngine.AI.NavMeshHit hit; // NavMesh Sampling Info Container
        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        UnityEngine.AI.NavMesh.SamplePosition(randomPos, out hit, maxDistance, UnityEngine.AI.NavMesh.AllAreas);

        return hit.position;
    }

}
