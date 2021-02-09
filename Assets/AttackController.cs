using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;


public class AttackController : MonoBehaviour
{
    [SerializeField] private RuntimeAnimatorController attackController;
    private RuntimeAnimatorController defaultController;
    private Animator anim;
    private Component controller;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        defaultController = anim.runtimeAnimatorController;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.runtimeAnimatorController = attackController;
            GetComponent<vThirdPersonInput>().enabled = false;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
       
        if(Input.GetMouseButtonUp(0)) {

                    anim.runtimeAnimatorController = defaultController;
            GetComponent<vThirdPersonInput>().enabled = true;

        }
    }
}
