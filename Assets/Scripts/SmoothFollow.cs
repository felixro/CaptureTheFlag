using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
	public float smoothDampTime = 0.2f;
	[HideInInspector]
	public new Transform transform;
	public Vector3 cameraOffset;
	public bool useFixedUpdate = false;
    public Transform target;

	private Vector3 _smoothDampVelocity;
	
	void Awake()
	{
		transform = gameObject.transform;
	}

	void LateUpdate()
	{
		if(!useFixedUpdate)
			updateCameraPosition();
	}


	void FixedUpdate()
	{
		if(useFixedUpdate)
        {
			updateCameraPosition();
        }
	}
        
	void updateCameraPosition()
	{
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10);

        transform.position = Vector3.SmoothDamp( transform.position, targetPosition - cameraOffset, ref _smoothDampVelocity, smoothDampTime );
	}
	
}
