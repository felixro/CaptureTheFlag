using UnityEngine;
using System.Collections;

public class PlayerAttackAction : IAction 
{
    private Transform transform;

    private Transform playerTarget;

    public PlayerAttackAction(
        Transform transform,
        Transform playerTarget
    )
    {
        this.transform = transform;
        this.playerTarget = playerTarget;
    }

    public Transform GetCurrentTarget()
    {
        return playerTarget;
    }
}
