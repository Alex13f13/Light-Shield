using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
	private Transform target;
	private int wavepointIndex = 0;

	private Enemy enemy;

	public Transform EnemyRotate;

	public AudioSource audiosource;
	public AudioClip WaveSound;

	void Start()
    {
		enemy = GetComponent<Enemy>();
		audiosource = GameObject.Find("END").GetComponent<AudioSource>();

		if (enemy.gameObject.tag == "EnemyFly")
		{
			target = WayPointsFly.Waypoints[0];
		}
		else
		{
			target = WayPoints.Waypoints[0];
		}
	}

	void Update()
	{
		Vector3 dir;
		dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(EnemyRotate.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
		EnemyRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWayPoint();
		}

		enemy.speed = enemy.Startspeed;
	}

	#region Funciones

	void GetNextWayPoint()
	{
		if (wavepointIndex >= WayPoints.Waypoints.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		
		if (enemy.gameObject.tag == "EnemyFly")
		{
			target = WayPointsFly.Waypoints[wavepointIndex];
		}
		else
		{
			target = WayPoints.Waypoints[wavepointIndex];
		}
	}

	void EndPath()
	{
		audiosource.PlayOneShot(WaveSound);
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}

	#endregion
}
