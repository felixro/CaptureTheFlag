using UnityEngine;
using System.Collections;

public class FlagGrabAction : IAction 
{
    private Transform transform;

    private Transform flagTarget;
    private Transform baseTarget;

    public FlagGrabAction(
        Transform transform,
        Transform flagTarget, 
        Transform baseTarget
    )
    {
        this.transform = transform;
        this.flagTarget = flagTarget;
        this.baseTarget = baseTarget;
    }

    public Transform GetCurrentTarget()
    {
        if (transform.Find("Green Flag") != null)
        {
            return baseTarget;
        }

        return flagTarget;
    }
}
