using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.5f;
    public bool mouseHover = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Hover();

            if (mouseHover)
            {
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            }
        }
        else
        {
            mouseHover = false;
        }
    }

    /// <summary>
    /// Detects if mouse is hovering over an object with tag "Pickup"
    /// </summary>
    public void Hover()
    {
        Ray ray;
        RaycastHit2D hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Pickup")
            {
                //Debug.Log("object hit");
                mouseHover = true;
            }
        }
    }
}
