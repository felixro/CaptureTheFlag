using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Behavior : MonoBehaviour 
{
    public BehaviorType behaviorType;

    public Transform flagTarget;
    public Transform playerTarget;
    public Transform homeBaseTarget;

    private Transform currentTarget;

    private IAction action;

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
        Transform flagTarget, 
        Transform playerTarget, 
        Transform homeBaseTarget
    )
    {
        this.flagTarget = flagTarget;   
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
            action = new FlagGrabAction(transform, flagTarget, homeBaseTarget);
            break;
        case BehaviorType.PLAYER_ONLY:
            action = new PlayerAttackAction(transform, playerTarget);
            break;
        case BehaviorType.FLAG_AND_PLAYER:
            action = new FlagAndAttackAction(transform, playerTarget, flagTarget, homeBaseTarget);
            break;
        default:
            currentTarget = playerTarget;
            return;
        }

        currentTarget = action.GetCurrentTarget();
    }
}
