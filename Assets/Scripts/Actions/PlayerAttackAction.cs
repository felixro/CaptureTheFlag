using UnityEngine;
using System.Collections;

public class PlayerAttackAction : AbstractAction 
{
    public PlayerAttackAction(
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

        if (flagOwner != null && flagOwner.Equals(transform))
        {
            // we are carrying the flag - go back to base
            return baseTarget;
        }

        return playerTarget;
    }
}
