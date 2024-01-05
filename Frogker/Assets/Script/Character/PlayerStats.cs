using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    #region Variables
	//Health
	public Slider healthBarPlayer;
    int maxHealth = 50;
	int currentHealth;
	//HealthPotions
	public GameObject[] potionsArray;
	private int countPotions;
	int healing = 10;

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

	//Health Potions
	public void CurrentHealthPotions(int consumePotion)
    {
			Destroy(potionsArray[consumePotion].gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//al inserta la tecla E se toma la pocion que restaura vida y quita una
        {
			if(countPotions != 0)
            {
				if(currentHealth == maxHealth)
				{
					//sonido
					Debug.Log("Tienes toda la vida, no puedes usar otra pocion");
					
				}
				else
				{
					currentHealth += healing;

					if (currentHealth > maxHealth)
					{
						currentHealth = maxHealth;//sumo la cantidad que cura
						SetHealth(currentHealth);//se setea en la barra el healing de la pocion
						countPotions -= 1;
						CurrentHealthPotions(countPotions);//se consume una pocion, menos una pocion
						
					}
					else
					{
						SetHealth(currentHealth);//se setea en la barra el healing de la pocion
						countPotions -= 1;
						CurrentHealthPotions(countPotions);//se consume una pocion, menos una pocion
						
					}
				
			
                }

            }
            else
            {
				//sonido
				Debug.Log("Te quedaste sin pociones");
			}
			

		}
    }


    //Player health
    void Start()
	{
		currentHealth = maxHealth;//medir la vida maxima con la actual, se puede trackear para el guardado
		SetMaxHealth(maxHealth);//se hace el set con respecto a la vida en la barra UI
		countPotions = potionsArray.Length;

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
