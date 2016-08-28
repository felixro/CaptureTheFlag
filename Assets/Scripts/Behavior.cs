using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Behavior : MonoBehaviour 
{
    public BehaviorType behaviorType;

    public GameObject flagGameObject;
    public Transform playerTarget;
    public Transform homeBaseTarget;

    private Transform currentTarget;

    private AbstractAction action;

	void Start ()
    {
        if (behaviorType == BehaviorType.RANDOM)
        {
            int nrOfBehaviorTypes = System.Enum.GetValues(typeof(BehaviorType)).Length - 1;
            behaviorType = (BehaviorType)Random.Range(0, nrOfBehaviorTypes);
        }

        CheckBehavior();
	}

    void Update()
    {
        CheckBehavior();
    }

    public void SetTargets(
        GameObject flagGameObject, 
        Transform playerTarget, 
        Transform homeBaseTarget
    )
    {
        this.flagGameObject = flagGameObject;   
        this.playerTarget = playerTarget;
        this.homeBaseTarget = homeBaseTarget;
    }

    public Transform GetCurrentTarget()
    {
        return currentTarget;
    }

    private void CheckBehavior()
    {
        switch(behaviorType)
        {
        case BehaviorType.FLAG_ONLY:
            action = new FlagGrabAction(transform, playerTarget, flagGameObject, homeBaseTarget);
            break;
        case BehaviorType.PLAYER_ONLY:
            action = new PlayerAttackAction(transform, playerTarget, flagGameObject, homeBaseTarget);
            break;
        case BehaviorType.FLAG_AND_PLAYER:
            action = new FlagAndAttackAction(transform, playerTarget, flagGameObject, homeBaseTarget);
            break;
        default:
            currentTarget = playerTarget;
            return;
        }

        currentTarget = action.GetCurrentTarget();
    }
}
