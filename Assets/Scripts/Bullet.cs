using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f ,ExplosionRadius = 0f;
	public int damage = 50;

	public GameObject ImpactEffect;

    void Update()
    {
		if (target == null)
		{
            Destroy(gameObject);
            return;
		}

        Vector3 dir = target.position - transform.position; //Dirección de la bala

        float DistanceFrame = speed * Time.deltaTime;

		if (dir.magnitude <= DistanceFrame)
		{
            HitTarget();
            return;
		}

        transform.Translate(dir.normalized * DistanceFrame, Space.World);
        transform.LookAt(target);
    }

    #region Funciones

    public void Seek (Transform Target)
	{
        target = Target;
	}

    void HitTarget()
	{
        GameObject effectsIns = /*(GameObject)*/ Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectsIns, 4f);

		if (ExplosionRadius > 0f)
		{
            Explote();
		}
		else
		{
            Damage(target);
		}

        Destroy(gameObject);
	}

    void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();

		if(e != null)
		{
			e.TakeDamage(damage);
		}
    }

    void Explote()
	{
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);

		foreach (Collider collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
                Damage(collider.transform);
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
	}

	#endregion
}
