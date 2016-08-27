using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObstacleHandler : MonoBehaviour 
{
    private static string OBSTACLE_NAME = "Obstacle";

    List<GameObject> obstacles;

	void Start () 
    {
        AstarPath.active.Scan();

        obstacles = new List<GameObject>(GameObject.FindGameObjectsWithTag(OBSTACLE_NAME));

        InvokeRepeating("CheckForObstacles", 0, 0.5F);
	}

    private void CheckForObstacles()
    {
        AstarPath.active.Scan();
        /*
        List<GameObject> latestObstacles = new List<GameObject>(GameObject.FindGameObjectsWithTag(OBSTACLE_NAME));

        List<GameObject> newlyAddedObstacles = obstacles.Except(latestObstacles).Concat(latestObstacles.Except(obstacles)).ToList();

        int nrOfNewlyAddedObstacles = newlyAddedObstacles.Count;
        if (nrOfNewlyAddedObstacles > 0)
        {
            Debug.Log(nrOfNewlyAddedObstacles + " new obstacles detected, re-scanning paths");
            AstarPath.active.Scan();

            obstacles = latestObstacles;
        }
        */
    }
}
