using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float Startspeed = 10f;

	[HideInInspector]
	public float speed;

	public int GiveMoney = 50;
	public int GiveScore;

	public float Starthealth = 100;
	private float health;

	public GameObject DeathEffect;

	[Header("Cosas UI")]
	public Image healthbar;

	private bool isDead = false;

	void Start()
	{
		speed = Startspeed;
		health = Starthealth;
	}

	#region Funciones	

	public void TakeDamage(float amount)
	{
		health -= amount;

		healthbar.fillAmount = health / Starthealth;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void Slow (float pct)
	{
		speed = Startspeed * (1f - pct);
	}

	void Die()
	{
		isDead = true;

		PlayerStats.Money += GiveMoney;
		PlayerStats.Score += GiveScore;

		GameObject effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

	#endregion
}
