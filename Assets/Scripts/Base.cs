using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour 
{
    public BaseType baseType;
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerFlag" || other.gameObject.tag == "EnemyFlag")
        {
            FlagHandler flagHandler = other.gameObject.GetComponent<FlagHandler>();

            FlagType flagType = flagHandler.GetFlagType();

            if (baseType == BaseType.PLAYER && flagType == FlagType.ENEMY)
            {
                // TODO: Add points for player
                flagHandler.ResetPosition();
            }
            else if (baseType == BaseType.ENEMY && flagType == FlagType.PLAYER)
            {
                // TODO: Add points for enemy
                flagHandler.ResetPosition();
            }
        }
    }
}
