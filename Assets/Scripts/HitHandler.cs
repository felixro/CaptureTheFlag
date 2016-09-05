using UnityEngine;
using System.Collections;

public class HitHandler : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        {
            transform.parent = other.transform;

            Rigidbody2D bulletRigidBody = transform.gameObject.GetComponent<Rigidbody2D>();
            PolygonCollider2D collider = transform.gameObject.GetComponent<PolygonCollider2D>();

            Destroy(bulletRigidBody);
            Destroy(collider);

            if (other.tag.Equals("Enemy"))
            {
                other.GetComponent<EnemyHitHandler>().Hit();
            }
        }
    }
}
