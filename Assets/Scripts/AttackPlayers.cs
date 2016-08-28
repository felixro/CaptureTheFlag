using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackPlayers : MonoBehaviour 
{
    public string[] tagsToAttack;
    public float distanceOfAttack = 15f;
    public float shotFrequency = 1f;
    public float shotSpeed = 1500f;

    public GameObject _shotPrefab;

    private bool _canFire = true;

    private CannonHandler cannonHandler;
    private GameObject bulletExit;

    public void Start()
    {
        cannonHandler = GetComponentInChildren<CannonHandler>();
    }

    public void Update()
    {
        if (!_canFire)
        {
            return;
        }

        List<GameObject> potTargets = new List<GameObject>();
        for (int i = 0; i < tagsToAttack.Length; i++)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(tagsToAttack[i]);

            potTargets.AddRange(targets);
        }

        // find closest target
        GameObject closestTarget = null;
        float smallestDistance = float.MaxValue;
        foreach (GameObject target in potTargets)
        {
            if (!target.active)
            {
                // target not active, ignore it
                continue;
            }
                
            float distance = Vector3.Distance (transform.position, target.transform.position);

            if (distance <= distanceOfAttack && distance < smallestDistance)
            {
                smallestDistance = distance;
                closestTarget = target;
            }
        }

        if (closestTarget != null)
        {
            FireShot(closestTarget.transform);
        }
    }

    private void FireShot(Transform target)
    {
        Vector3 relativePosition = target.position - transform.position;
        relativePosition.Normalize();

        float angle = Mathf.Atan2(relativePosition.y, relativePosition.x) * Mathf.Rad2Deg;

        cannonHandler.Rotate(angle);

        GameObject projectile = (GameObject)Instantiate(_shotPrefab, cannonHandler.GetBulletExit(), Quaternion.identity);
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Rigidbody2D body = projectile.GetComponent<Rigidbody2D>();

        body.AddForce(
            relativePosition * shotSpeed,
            ForceMode2D.Force
        );
            
        StartCoroutine(Fire(shotFrequency));
        //laser.PlaySound();
    }

    IEnumerator Fire(float fireFrequency)
    {
        _canFire = false;
        yield return new WaitForSeconds(1f/fireFrequency);
        _canFire = true;
    }
}
