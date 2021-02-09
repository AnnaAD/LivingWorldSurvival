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
    public float waitTimer;
    private float timer;
    public Rigidbody player;
    public Rigidbody npc;
    public float rotationSpeed = 200f;
    public bool facing = false;
    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      timer = waitTimer;
    }

    // Update is called once per frame
    void Update()
    {
      IdleWalk();

    }

    void IdleWalk(){
      if (timer < waitTimer) {
        timer += Time.deltaTime;
        return;
      }

      float dist = Vector3.Distance(player.position, transform.position);
      if(dist< 4){
        animator.SetBool("walk", false);
        agent.isStopped = true;
        if(facing == false){
          transform.LookAt(player.transform);
          facing = true;
          // RotateTowards(player.transform);
        }
        return;
      }

      facing = false;

      if(agent.isStopped == false){
          animator.SetBool("walk", true);
      }else{
          Vector3 newPos = GetRandomPoint(center, 5f);
          agent.SetDestination(newPos);
          agent.isStopped = false;
      }

      if(agent.remainingDistance <= agent.stoppingDistance){
        animator.SetBool("walk", false);
        agent.isStopped = true;
        timer = 0;
      }

    }

    void GoToSleep(){

    }

    public void RotateTowards(Transform target) {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
     }

    public Vector3 GetRandomPoint(Vector3 center, float maxDistance) {
        // Get Random Point inside Sphere which position is center, radius is maxDistance
        // Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;
        Vector3 randomPos = new Vector3(center.x + Random.Range(-30.0f, 30.0f), center.y, center.z + Random.Range(-30.0f, 30.0f));
        UnityEngine.AI.NavMeshHit hit; // NavMesh Sampling Info Container
        // from randomPos find a nearest point on NavMesh surface in range of maxDistance
        UnityEngine.AI.NavMesh.SamplePosition(randomPos, out hit, maxDistance, UnityEngine.AI.NavMesh.AllAreas);
        return hit.position;
    }

}
