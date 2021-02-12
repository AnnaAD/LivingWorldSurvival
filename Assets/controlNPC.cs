using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlNPC : MonoBehaviour
{
    public Animator animator;
    public Vector3 center;
    public UnityEngine.AI.NavMeshAgent agent;

    public float waitTimer;
    public float sleepTimer;
    private float timer;

    public Rigidbody player;
    public Rigidbody npc;
    public float rotationSpeed = 200f;
    public bool facing = false;
    public string mode;
    public bool enroute;
    public  GameObject closest = null;
    public Inventory inventory;

    [SerializeField] private GameObject drop;

    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      timer = waitTimer;
      sleepTimer = 0;
      inventory = new Inventory();
      enroute = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(mode == "idle"){
          IdleWalk();
      }else if(mode == "find food"){
          FindFood();
      }else if(mode == "sleep"){
          GoToSleep();
      }

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


    void FindFood(){
      if(!enroute){
        GameObject[] foods;
        foods = GameObject.FindGameObjectsWithTag("food");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject food in foods){
            Vector3 diff = food.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance){
                closest = food;
                distance = curDistance;
            }
         }
         agent.SetDestination(closest.transform.position);
         animator.SetBool("walk", true);
         enroute = true;
      }

      if(agent.remainingDistance <= agent.stoppingDistance +1){
        animator.SetBool("walk", false);
        animator.SetTrigger("pick up");
        agent.isStopped = true;
        enroute = false;
        mode = "idle";
        timer = -5;
      }

    }

    void addToInventory(){
      inventory.addItem(closest.GetComponent<Pickup>().getItem());
      Destroy(closest);
    }

    void GoToSleep(){
      if(sleepTimer == 0){
        animator.SetBool("walk", false);
        animator.SetBool("sleep", true);
        Instantiate(ItemAssets.Instance.deployedTent, transform.position, ItemAssets.Instance.deployedTent.transform.rotation);
      }

      sleepTimer += Time.deltaTime;

      if(sleepTimer > 10){
        animator.SetBool("sleep", false);
        sleepTimer = 0;
        mode = "idle";
      }
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

    public void OnTriggerEnter(Collider other)
    {
        HealthSystem health = GetComponent<PlayerStats>().health;
        if (other.gameObject.tag == "Damage")
        {
            health.Damage(other.gameObject.GetComponent<DamageStats>().damage);
            if (health.GetHealth() <= 0)
            {
                Destroy(this.gameObject);
                Instantiate(drop, transform.position, Quaternion.identity);
                foreach (Item i in inventory.GetItems())
                {
                    Instantiate(i.getPickup(), transform.position + new Vector3(Random.Range(-1f,1f), 0, Random.Range(-1f, 1f)), Quaternion.identity);
                }
            }
        }

    }

    private float getItemValue(Item i)
    {
        return 1;
    }

    public float evalItems(Inventory items)
    {
        float total = 0f;
        foreach(Item i in items.GetItems())
        {
            total += getItemValue(i);
        }
        return total;
    }

}
