using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    #region Variables
	//Health
	public Slider healthBarPlayer;
    public int maxHealth = 50;
	int currentHealth;
	

	//Damage
	int swordDamage = 5;

	#endregion

	#region Damage-Health Player
	//HealthBar
	public void SetMaxHealth(int maxHealth)
    {
		healthBarPlayer.maxValue = maxHealth;
		healthBarPlayer.value = maxHealth;
    }

	public void SetHealth(int health)
    {
		healthBarPlayer.value = health;

	}

	//Health Potions
	public void HealthPotions()
    {

    }




	//Player health
	void Start()
	{
		currentHealth = maxHealth;
		SetMaxHealth(maxHealth);
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
