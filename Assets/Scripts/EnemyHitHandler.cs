using UnityEngine;
using System.Collections;

public class EnemyHitHandler : MonoBehaviour 
{
    private EnemyAI enemyAI;

    public void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void Hit()
    {
        float curSpeed = enemyAI.GetSpeed();
        if (curSpeed >= 1.0f)
        {
            enemyAI.SetSpeed(curSpeed - 0.5f);
        }
    }
}
