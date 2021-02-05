using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int health = 20;
	public int hunger = 10;
	public int cold = 10;

    public bool warm = false;

	public float hunger_counter;
    public float cold_counter;

    void Update()
	{
		hunger_counter += Time.deltaTime;
        cold_counter += Time.deltaTime;

        if(hunger_counter > 20)
		{
			hunger -= 1;
			hunger_counter = 0;
            if (hunger < 1)
            {
                health--;
            }
        }

        if(cold_counter > 10)
        {
            if (warm)
            {
                cold += 2;
                cold_counter = 0;
            }
            cold -= 1;
            cold_counter = 0;

            if(cold < 1)
            {
                health--;
            }
        }

        if(cold > 10) { cold = 10; }
        if(hunger > 10) { hunger = 10; }
        if(cold < 0) { cold = 0; }
        if (hunger < 0) { hunger = 0; }

    }

    public float getStat(string name)
    {
        if (name == "health")
        {
            return health / 20f;
        }

        if(name == "hunger")
        {
            return hunger / 10f;
        }

        if (name == "cold")
        {
            return cold / 10f;
        }

        return -1;

    }
}
