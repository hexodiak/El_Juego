using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Variables

    public int maxHealth = 50;
	int currentHealth;

	int swordDamage = 5;

    #endregion

    #region Damage-Health Player
	void Start()
	{
		currentHealth = maxHealth;
	}

    public void TakeDamagePlayer(int damage)
	{

		currentHealth -= damage;

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
