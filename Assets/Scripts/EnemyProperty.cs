using UnityEngine;
using System.Collections;

public class EnemyProperty : MonoBehaviour
{
    public int health = 100;

    private EnemyAI enemyAI;

    public void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void ReduceHealth(int decrement)
    {
        health -= decrement;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
            
        float curSpeed = enemyAI.GetSpeed();
        if (curSpeed >= 1.0f)
        {
            enemyAI.SetSpeed(curSpeed - 0.5f);
        }
    }
}
