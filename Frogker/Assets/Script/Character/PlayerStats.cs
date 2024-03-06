using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    #region Variables
	//Health
	public Slider healthBarPlayer;
    int maxHealth = 20;
	int currentHealth;
	

	//Damage
	int swordDamage = 5;

	#endregion

	#region Damage-Health Player
	//HealthBar
	public void SetMaxHealth(int maxHealth)//setear la vida maxima como parametos en la barra UI
    {
		healthBarPlayer.maxValue = maxHealth;
		healthBarPlayer.value = maxHealth;
    }
	public void SetHealth(int health)//setear la vida actual que va teniendo el personaje
    {
		healthBarPlayer.value = health;

	}

	

    void Update()
    {
        
    }


    //Player health
    void Start()
	{
		currentHealth = maxHealth;//medir la vida maxima con la actual, se puede trackear para el guardado
		SetMaxHealth(maxHealth);//se hace el set con respecto a la vida en la barra UI
		

	}

    public void TakeDamagePlayer(int damage)
	{

		currentHealth -= damage;
		SetHealth(currentHealth);

		//Hurt animation
		//animator.SetTrigger("nombre de animacion");

		if (currentHealth <= 0)
		{
			//Die animation
			//animator.SetTrigger("nombre de animacion");
			DiePlayer();
		}
		Debug.Log("Personaje golpeado --- " + currentHealth);
	}

	void DiePlayer()
	{

		//Die animation
		//animator.SetBool("animacion muerte", true);

		
		Destroy(gameObject);
		this.enabled = false;
		//Application.LoadLevel(Application.loadedLevel);
		Debug.Log("Personaje muerto");
	}


	#endregion


}
