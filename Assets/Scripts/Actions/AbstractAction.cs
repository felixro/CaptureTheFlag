using UnityEngine;
using System.Collections;

public abstract class AbstractAction
{
    public abstract Transform GetCurrentTarget();

    protected Transform transform;
    protected Transform playerTarget;
    protected GameObject flagGameObject;
    protected Transform baseTarget;

    protected AbstractAction(
        Transform transform,
        Transform playerTarget,
        GameObject flagGameObject,
        Transform baseTarget
    )
    {
        this.transform = transform;
        this.playerTarget = playerTarget;
        this.flagGameObject = flagGameObject;
        this.baseTarget = baseTarget;
    }
}
