using UnityEngine;
using System.Collections;

public class Placement : MonoBehaviour 
{
    private static Color ORIGINAL_COLOR = new Color(1, 1, 1);
    private static Color COLLISION_COLOR = new Color(1, 0, 0);

    private bool canPlaceHere;
    private SpriteRenderer renderer;

    void Start()
    {
        canPlaceHere = true;
        renderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            canPlaceHere = false;
            renderer.color = COLLISION_COLOR;
        }
    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            canPlaceHere = true;
            renderer.color = ORIGINAL_COLOR;
        }
    }

    public bool GetCanPlaceHere()
    {
        return canPlaceHere;
    }
}
