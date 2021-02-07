using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    private HealthSystem health;
    [SerializeField] private GameObject drop;
    // Start is called before the first frame update
    void Start()
    {
        health = new HealthSystem(20);
        transform.Find("HealthBar").GetComponent<HealthBar>().Setup(health);
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
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Damage")
        {
            health.Damage(other.gameObject.GetComponent<DamageStats>().damage);
        }
    }
}
