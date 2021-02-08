using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
	public int hunger = 10;
	public int tired = 10;

    public HealthSystem health;


	public float hunger_counter;
    public float tired_counter;

    public Text HungerText;
    public Text TiredText;

    void Update()
	{
		hunger_counter += Time.deltaTime;
        tired_counter += Time.deltaTime;

        if(hunger_counter > 20)
		{
			hunger -= 1;
			hunger_counter = 0;
            if (hunger < 1)
            {
                health.Damage(1);
            }
        }

        if(tired_counter > 10)
        {
            tired -= 1;
            tired_counter = 0;

            if(tired < 1)
            {
                health.Damage(1);
            }
        }

        if(tired > 10) { tired = 10; }
        if(hunger > 10) { hunger = 10; }
        if(tired < 0) { tired = 0; }
        if (hunger < 0) { hunger = 0; }

        HungerText.text = "Hunger: " + hunger;
        TiredText.text = "Tired: " + tired;

    }

    public float getStat(string name)
    {
        if (name == "health")
        {
            return health.GetHealthPercent();
        }

        if(name == "hunger")
        {
            return hunger / 10f;
        }

        if (name == "tired")
        {
            return tired / 10f;
        }

        return -1;

    }
}
