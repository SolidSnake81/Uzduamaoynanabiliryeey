using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHealth : MonoBehaviour
{

	public int health = 9;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public Slider hb;

	void Update()
	{
		hb.value = health;
	}
		public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 8)
		{
			GetComponent<Animator>().SetBool("ER", true);
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{


		GetComponent<Animator>().SetBool("DeaD", true);
		GetComponent<Animator>().SetTrigger("Death");

		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
