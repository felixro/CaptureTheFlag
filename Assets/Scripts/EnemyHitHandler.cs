using UnityEngine;
using System.Collections;

public class EnemyHitHandler : MonoBehaviour 
{
    private EnemyProperty enemyProperty;

    public void Start()
    {
        enemyProperty = GetComponent<EnemyProperty>();
    }

    public void Hit()
    {
        enemyProperty.ReduceHealth(20);
    }
}
