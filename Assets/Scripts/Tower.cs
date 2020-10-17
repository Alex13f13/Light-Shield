using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    private Transform target;
	private Enemy Targetenemy;

	[Header("General")]//Configuraciónes que pueden ser cambiadas dependiendo de la torreta

	public float range = 15f;

	[Header("Uso de las Balas")]
	public GameObject bulletPrefab;
	public float FireRate = 1f;
	private float fireCountDown = 0f;

	[Header("Uso del Laser")]
	public bool useLaser = false;	
	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public Light impactLight;
	public int DamageOverTime = 30;
	public float Slowpct = .4f;

	[Header("Campos de Configuración de Unity")]//No debe ser cambiado por el usuario

	public string EnemyTag = "Enemy";

	public Transform partRotate, firePoint;
	public float rotateSpeed = 10f;

	//public List<GameObject> vfx = new List<GameObject>();
	//private GameObject effectToSpawn;

	void Start()
    {
		//effectToSpawn = vfx[0];

		InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
	{
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies)
		{
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
            target = nearestEnemy.transform;
			Targetenemy = nearestEnemy.GetComponent<Enemy>();
		}
		else
		{
			target = null;
		}
	}

    void Update()
    {
		if (target == null)
		{
			if (useLaser)
			{
				if (lineRenderer.enabled)
				{
					lineRenderer.enabled = false;
					impactEffect.Stop();
					impactLight.enabled = false;
				}
			}
            return;
		}

		LookOnTarget();

		if (useLaser)
		{
			Laser();
		}
		else
		{
			//Para disparar
			if (fireCountDown <= 0f)
			{
				Shoot();
				fireCountDown = 1f / FireRate;
			}

			fireCountDown -= Time.deltaTime; //Nos aseguramos que el contador es igual en todos los dispositivos
		}		
    }

	#region Funciones

	void OnDrawGizmosSelected()//Rango de la torreta dibujado con forma de esfera
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
	}

	void LookOnTarget()
	{
		//Rotación de la torreta para apuntar al enemigo
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
		partRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	void Laser()
	{
		Targetenemy.TakeDamage(DamageOverTime * Time.deltaTime);
		Targetenemy.Slow(Slowpct);


		if (!lineRenderer.enabled)
		{
			lineRenderer.enabled = true;
			impactEffect.Play();
			impactLight.enabled = true;
		}

		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);

		Vector3 dir = firePoint.position - target.position;
		impactEffect.transform.position = target.position + dir.normalized * 1.2f;
		impactEffect.transform.rotation = Quaternion.LookRotation(dir);	
	}

	void Shoot()
	{
		//GameObject VFX = Instantiate(effectToSpawn, firePoint.position, firePoint.rotation);

		GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
		{
			bullet.Seek(target);
		}
	}

	#endregion
}
