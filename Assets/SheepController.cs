using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    private HealthSystem health;
    [SerializeField] private GameObject drop;
    private Vector2 targetDestination;
    private Rigidbody rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        health = new HealthSystem(4);
        transform.Find("HealthBar").GetComponent<HealthBar>().Setup(health);
        targetDestination = new Vector2(transform.position.x, transform.position.z);
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health.GetHealth());
        if(health.GetHealth() <= 0)
        {
            Debug.Log("die");
            Destroy(this.gameObject);
            Instantiate(drop, transform.position, Quaternion.identity);
        }

        if(Vector2.Distance(new Vector2(transform.position.x, transform.position.z), targetDestination) < 1f)
        {
            Vector2 newPosOffset = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            targetDestination = targetDestination + newPosOffset;
        }

       

        transform.LookAt(new Vector3(targetDestination.x, transform.position.y, targetDestination.y));

        rb.velocity = transform.forward * 3f;

        animator.SetFloat("Speed", rb.velocity.magnitude);



    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Damage")
        {
            health.Damage(other.gameObject.GetComponent<DamageStats>().damage);
            Vector3 moveDirection = rb.transform.position - other.transform.position;
            rb.AddForce(moveDirection.normalized * -500f);
        }
    }
}
