using UnityEngine;
using System.Collections;

public class MovementDirection 
{
    private float previousPosition;
    private float nextPosition;

    private float movementDirection;

    public MovementDirection()
    {
        previousPosition = 0.0f;
        nextPosition = 0.0f;
        movementDirection = 1.0f;
    }
	
    public void SetMovementDirection(float direction)
    {
        movementDirection = direction;
    }

    public void SetPreviousPosition(float position)
    {
        previousPosition = position;
    }

    public void SetNextPosition(float position)
    {
        nextPosition = position;
    }

    public float GetMovementDirection()
    {
        if (nextPosition - previousPosition != 0)
        {
            movementDirection = Mathf.Sign(nextPosition - previousPosition);
        }

        return movementDirection;
    }
}
