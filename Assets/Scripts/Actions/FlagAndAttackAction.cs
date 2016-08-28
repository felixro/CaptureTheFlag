using UnityEngine;
using System.Collections;

public class FlagAndAttackAction : AbstractAction 
{
    private float distToFlagToGrab = 10f;

    public FlagAndAttackAction(
        Transform transform,
        Transform playerTarget,
        GameObject flagGameObject,
        Transform baseTarget
    ) : base(transform, playerTarget, flagGameObject, baseTarget)
    {
        
    }

    public override Transform GetCurrentTarget()
    {
        Transform flagOwner = flagGameObject.transform.parent;

        if (flagOwner != null)
        {
            if (flagOwner.Equals(transform))
            {
                // we are carrying the flag - go back to base
                return baseTarget;
            }
            else if (flagOwner.tag == "Enemy")
            {
                // one of the other "enemies" has the flag, go after the player
                return playerTarget;
            }
            else
            {
                // player has the flag - go get him
                return playerTarget;
            }
        }

        float curDistToFlag = Vector3.Distance(flagGameObject.transform.position, transform.position);
        float curDistToPlayer = Vector3.Distance(playerTarget.position, transform.position);

        // grab the flag if it is close enough and closer than the player
        if (curDistToFlag <= distToFlagToGrab && curDistToPlayer > curDistToFlag)
        {
            return flagGameObject.transform;
        }

        return playerTarget;
    }
}
