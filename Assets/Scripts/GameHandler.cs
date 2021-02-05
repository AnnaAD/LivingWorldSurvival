using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour{

	public HealthBar healthBar;
    
    private void Start(){
    	HealthSystem healthSystem = new HealthSystem(100);
        Debug.Log(healthBar);
    	healthBar.Setup(healthSystem);

    	Debug.Log("Health: " + healthSystem.GetHealthPercent());
    	healthSystem.Damage(10);
    	Debug.Log("Health: " + healthSystem.GetHealthPercent());
		/*healthSystem.Heal(10);
    	Debug.Log("Health: " + healthSystem.GetHealthPercent());*/
    }
}
