using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject enemyPrefab;
    public GameObject player;
    public GameObject playerFlag;

    public Transform enemyBase;

    public int nrOfEnemies = 5;

    private List<GameObject> enemies;

	void Start () 
    {
        enemies = new List<GameObject>();

        for (int i = 0; i < nrOfEnemies; i++)
        {
            GameObject enemy = 
                Instantiate(
                    enemyPrefab, 
                    enemyBase.position + 
                    new Vector3(
                        Random.Range(-5.0f, 5.0f),
                        Random.Range(-5.0f, 5.0f), 
                        0.0f
                    ), 
                    Quaternion.identity
                ) as GameObject;

            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();

            enemyAI.SetTargets(
                playerFlag, 
                player.transform, 
                enemyBase
            );

            enemies.Add(
                enemy
            );
        }
	}
}
