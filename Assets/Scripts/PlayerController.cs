using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float speed = 20.0F;

    private CharacterController controller;
    private Vector3 target;
    private MovementDirection direction;

    void Start()
    {
        target = transform.position;
        direction = new MovementDirection();
    }

    void FixedUpdate()
    {
        direction.SetPreviousPosition(transform.position.x);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        direction.SetNextPosition(transform.position.x);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && 
            ! EventSystem.current.IsPointerOverGameObject() &&
            ! DefensePlanner.isBuilderMode) 
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
    }

    public float GetMovementDirection()
    {
        return direction.GetMovementDirection();
    }
}
