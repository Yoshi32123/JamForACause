using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour
{
    [SerializeField] bool mouseHover = false;
    [SerializeField] GameObject element = null;
    private Vector3 mousePosition;
    [SerializeField] GameObject mainCam;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        gameManager = mainCam.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseHover && !gameManager.elementSelected)
        {
            mousePosition = Input.mousePosition;
            gameManager.elementStorage = Instantiate(element, Camera.main.ScreenToWorldPoint(mousePosition), Quaternion.identity);
            mouseHover = false;
            gameManager.elementSelected = true;
        }
    }

    /// <summary>
    /// Detects if mouse is hovering over an object with tag "Pickup"
    /// </summary>
    private void Hover()
    {
        Ray ray;
        RaycastHit2D hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Beaker")
            {
                if (hit.collider.name == gameObject.name)
                {
                    //Debug.Log(hit.collider.name);
                    mouseHover = true;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        Hover();
    }
}
