using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool elementSelected = false;
    public GameObject elementStorage;
    public GameObject dish;
    public int[] elements;

    void Awake()
    {
        elements = new int[] { 0, 0, 0, 0, 0 };
        /*
         index 0: Hydrogen
         index 1: Oxygen
         index 2: Iron
         index 3: Sodium
         index 4: Chlorine
         */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckPlacement();
        }
    }

    public void CheckPlacement()
    {
        if (elementSelected)
        {
            Ray ray;
            RaycastHit2D hit;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            

            if (hit.collider != null)
            {
                if (hit.collider.name == dish.gameObject.name)
                {
                    HandleElementDrop();
                    elementSelected = false;
                }
            }
        }
    }

    public void HandleElementDrop()
    {
        if (elementStorage.tag == "Hydrogen")
            elements[0]++;
        else if (elementStorage.tag == "Oxygen")
            elements[1]++;
        else if (elementStorage.tag == "Iron")
            elements[2]++;
        else if (elementStorage.tag == "Sodium")
            elements[3]++;
        else if (elementStorage.tag == "Chlorine")
            elements[4]++;

        Destroy(elementStorage);
    }
}
