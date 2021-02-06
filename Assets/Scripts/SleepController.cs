using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepController : MonoBehaviour
{

    [SerializeField] private RuntimeAnimatorController sleepController;
    private RuntimeAnimatorController defaultController;
    private Animator anim;
    private bool sleeping;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        defaultController = anim.runtimeAnimatorController;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            if (sleeping)
            {
                anim.runtimeAnimatorController = defaultController;
                sleeping = false;
            } else
            {
                sleeping = true;
                anim.runtimeAnimatorController = sleepController;
            }
        }
    }
}
