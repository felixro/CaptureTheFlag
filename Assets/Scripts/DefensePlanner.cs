using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DefensePlanner : MonoBehaviour 
{
    public static bool isBuilderMode;

    public GameObject boxPrefab;

    private bool isBuildingBox;
    private bool isBuildingTurret;

    private GameObject objectPreview;
	
    void Start()
    {
        isBuilderMode = false;
        isBuildingBox = true;
        isBuildingTurret = false;

        objectPreview = null;
    }

	// Update is called once per frame
	void Update () 
    {
        if (!isBuilderMode && objectPreview != null)
        {
            Destroy(objectPreview);
        }

        if (isBuilderMode && ! EventSystem.current.IsPointerOverGameObject())
        {
            if (isBuildingBox)
            {
                if (objectPreview == null)
                {
                    Vector3 curPosition = GetCurrentMousePosition();

                    objectPreview = Instantiate(boxPrefab, curPosition, Quaternion.identity) as GameObject;

                    // need to make the preview object non-kinematic in order for collision to work
                    Rigidbody2D rb = objectPreview.GetComponent<Rigidbody2D>();
                    rb.isKinematic = false;
                }
            }
        }

        if (objectPreview != null)
        {
            objectPreview.transform.position = GetCurrentMousePosition();
        }
            
        if (Input.GetMouseButtonDown(0) && 
            isBuilderMode &&
            ! EventSystem.current.IsPointerOverGameObject())
        {
            if (objectPreview == null)
            {
                throw new System.NullReferenceException("Object preview was empty");
            }
                
            Placement placement = objectPreview.GetComponent<Placement>();

            Debug.Log(placement.GetCanPlaceHere());

            if (placement.GetCanPlaceHere())
            {
                Instantiate(boxPrefab, GetCurrentMousePosition(), Quaternion.identity);

                Destroy(objectPreview);
            }
        }
	}

    public void SetBuilderMode(bool toggle)
    {
        isBuilderMode = toggle;
    }

    public void SetIsBuildingBox(bool toggle)
    {
        isBuildingBox = toggle;
    }

    public void SetIsBuildingTurret(bool toggle)
    {
        isBuildingTurret = toggle;
    }

    private Vector3 GetCurrentMousePosition()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objectPosition.z = 0.0f;

        return objectPosition;
    }
}
