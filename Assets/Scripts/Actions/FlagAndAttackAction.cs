using UnityEngine;
using System.Collections;

public class FlagAndAttackAction : IAction 
{
    private Transform transform;

    private Transform playerTarget;
    private Transform flagTarget;
    private Transform baseTarget;

    private float distToFlagToGrab = 10f;

    public FlagAndAttackAction(
        Transform transform,
        Transform playerTarget, 
        Transform flagTarget, 
        Transform baseTarget
    )
    {
        this.transform = transform;
        this.playerTarget = playerTarget;
        this.flagTarget = flagTarget;
        this.baseTarget = baseTarget;
    }

    public Transform GetCurrentTarget()
    {
        if (transform.Find("Green Flag") != null)
        {
            return baseTarget;
        }

        float curDistToFlag = Vector3.Distance(flagTarget.position, transform.position);
        float curDistToPlayer = Vector3.Distance(playerTarget.position, transform.position);

        // grab the flag if it is close enough and closer than the player
        if (curDistToFlag <= distToFlagToGrab && curDistToPlayer > curDistToFlag)
        {
            return flagTarget;
        }

        return playerTarget;
    }
}
