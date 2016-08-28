using UnityEngine;
using System.Collections;

public class CannonHandler : MonoBehaviour 
{
    private GameObject bulletExit;

	void Start () 
    {
        bulletExit = transform.Find("BulletExit").gameObject;
	}
	
    public void Rotate(float angle)
    {
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public Vector3 GetBulletExit()
    {
        return bulletExit.transform.position;
    }
}
