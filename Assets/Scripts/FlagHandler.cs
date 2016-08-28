using UnityEngine;
using System.Collections;

public class FlagHandler : MonoBehaviour 
{
    public FlagType flagType;

    private GameObject flagHolder = null;

    private Vector3 localPosition;
    private Quaternion localRotation;

    private Vector3 defaultPosition;

    void Start()
    {
        defaultPosition = transform.position;
    }

    void Update()
    {
        if (flagHolder != null)
        {
            float movementDirection = 1.0f;
            if (flagHolder.tag == "Player")
            {
                movementDirection = flagHolder.GetComponent<PlayerController>().GetMovementDirection();
            }
            else if (flagHolder.tag == "Enemy")
            {
                movementDirection = flagHolder.GetComponent<EnemyAI>().GetMovementDirection();
            }

            if (movementDirection == 1)
            {
                localPosition = new Vector3(-0.8f, -0.05f, 0f);
                localRotation = Quaternion.Euler(0f, 180f, -45f);
            }else if (movementDirection == -1)
            {
                localPosition = new Vector3(0.8f, -0.05f, 0f);
                localRotation = Quaternion.Euler(0f, 0f, -45f);
            }

            transform.parent = flagHolder.transform;
            transform.localPosition = localPosition;
            transform.localRotation = localRotation;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (flagHolder != null)
        {
            return;
        }

        if (transform.position.Equals(defaultPosition))
        {
            // flag has not been moved yet
            if (flagType == FlagType.PLAYER && other.gameObject.tag == "Enemy")
            {
                flagHolder = other.gameObject;
            }
            else if (flagType == FlagType.ENEMY && other.gameObject.tag == "Player")
            {
                flagHolder = other.gameObject;
            }
        }
        else if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            flagHolder = other.gameObject;
        }
    }

    public void DropFlag()
    {
        flagHolder = null;
        transform.parent = null;        
    }

    public void ResetPosition()
    {
        flagHolder = null;
        transform.parent = null;

        transform.position = defaultPosition;
        transform.rotation = Quaternion.identity;
    }

    public bool HasFlagHolder()
    {
        return flagHolder != null;
    }

    public FlagType GetFlagType()
    {
        return flagType;
    }
}
