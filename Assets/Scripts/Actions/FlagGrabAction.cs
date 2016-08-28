using UnityEngine;
using System.Collections;

public class FlagGrabAction : AbstractAction 
{
    public FlagGrabAction(
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

        return flagGameObject.transform;
    }
}
