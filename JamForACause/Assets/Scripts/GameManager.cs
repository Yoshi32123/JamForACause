﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Script Info:")]
    public GameObject orderManagerObject;
    public OrdersManager ordersManager;
    public GameObject scoreObject;
    public ScoreUI scoreUI;

    [Header("Element info:")]
    public bool elementSelected = false;
    public GameObject elementStorage;
    public GameObject dish;
    public int[] elements;
    public GameObject molecule = null;

    //Formulas
    private int[] waterFormula = new int[] { 2, 1, 0, 0, 0, 0};
    private int[] saltFormula = new int[] { 0, 0, 0, 1, 1, 0 };
    private int[] peroxideFormula = new int[] { 2, 2, 0, 0, 0, 0 };
    private int[] rustFormula = new int[] { 0, 3, 2, 0, 0, 0 };
    private int[] dryIceFormula = new int[] { 0, 2, 0, 0, 0, 1 };
    private int[] bakingSodaFormula = new int[] { 1, 3, 0, 1, 0, 1 };
    private int[] vinegarFormula = new int[] { 4, 2, 0, 0, 0, 2 };
    private int[] milkFormula = new int[] { 6, 3, 0, 0, 0, 3 };

    //Prefabs
    public GameObject water;
    public GameObject salt;
    public GameObject peroxide;
    public GameObject rust;
    public GameObject dryIce;
    public GameObject bakingSoda;
    public GameObject vinegar;
    public GameObject milk;

    // Start is called before the first frame update
    void Awake()
    {
        elements = new int[] { 0, 0, 0, 0, 0, 0 };
        /*
         index 0: Hydrogen
         index 1: Oxygen
         index 2: Iron
         index 3: Sodium
         index 4: Chlorine
         index 5: Carbon
         */
    }

    private void Start()
    {
        ordersManager = orderManagerObject.GetComponent<OrdersManager>();
        scoreUI = scoreObject.GetComponent<ScoreUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckPlacement();
        }

        if (Input.GetMouseButtonUp(0))
        {
            CheckOrders();
        }

        //test - remove later
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckCombination();
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
        else if (elementStorage.tag == "Carbon")
            elements[5]++;

        Destroy(elementStorage);
    }

    /// <summary>
    /// Checks if the added elements make a correct formula to create a molecule and instantiates if so, then checks if it matches one of the current orders.
    /// </summary>
    public void CheckCombination()
    {
        if (molecule != null)
        {
            Destroy(molecule);
            molecule = null;
        }

        if (CompareFormulas(elements, waterFormula))
        {
            ClearElements();
            molecule = Instantiate(water, new Vector3(dish.transform.position.x, dish.transform.position.y, 0), Quaternion.identity);
        }
        else if (CompareFormulas(elements, saltFormula))
        {
            ClearElements();
            molecule = Instantiate(salt, new Vector3(dish.transform.position.x, dish.transform.position.y, 0), Quaternion.identity);
        }
        else if (CompareFormulas(elements, peroxideFormula))
        {
            ClearElements();
            molecule = Instantiate(peroxide, new Vector3(dish.transform.position.x, dish.transform.position.y, 0), Quaternion.identity);
        }
        else if (CompareFormulas(elements, rustFormula))
        {
            ClearElements();
            molecule = Instantiate(rust, new Vector3(dish.transform.position.x, dish.transform.position.y, 0), Quaternion.identity);
        }
        else if (CompareFormulas(elements, dryIceFormula))
        {
            ClearElements();
            molecule = Instantiate(dryIce, new Vector3(dish.transform.position.x, dish.transform.position.y, 0), Quaternion.identity);
        }
        else if (CompareFormulas(elements, bakingSodaFormula))
        {
            ClearElements();
            molecule = Instantiate(bakingSoda, new Vector3(dish.transform.position.x, dish.transform.position.y, 0), Quaternion.identity);
        }
        else if (CompareFormulas(elements, vinegarFormula))
        {
            ClearElements();
            molecule = Instantiate(vinegar, new Vector3(dish.transform.position.x, dish.transform.position.y, 0), Quaternion.identity);
        }
        else if (CompareFormulas(elements, milkFormula))
        {
            ClearElements();
            molecule = Instantiate(milk, new Vector3(dish.transform.position.x, dish.transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            ClearElements();
            molecule = null;
        }

        
    }

    public bool CompareFormulas(int[] a, int[] b)
    {
        for(int i = 0; i < a.Length; i++)
        {
            if(a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Resets the elements array
    /// Function Attached to Clear Button
    /// </summary>
    public void ClearElements()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i] = 0;
        }
    }

    /// <summary>
    /// Calls the internal CheckCombination Function
    /// Function Attached to Create Button
    /// </summary>
    public void Create()
    {
        CheckCombination();
    }

    public void CheckOrders()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Debug.Log(mousePosition.x + ", " + mousePosition.y);

        int index = -1;

        if (molecule != null)
        {
            for (int i = 0; i < ordersManager.orders.Count; i++)
            {
                if (mousePosition.x > ordersManager.orders[i].transform.position.x - 1.2 &&
                    mousePosition.x < ordersManager.orders[i].transform.position.x + 1.2 &&
                    mousePosition.y > ordersManager.orders[i].transform.position.y - 1.2 &&
                    mousePosition.y < ordersManager.orders[i].transform.position.y + 1.2)
                {
                    if (ordersManager.MoleculeToString(ordersManager.orders[i].GetComponent<Order>().moleculeOrdered) == molecule.tag)
                    {
                        scoreUI.UpdateScore();
                        Destroy(molecule);
                        molecule = null;
                        index = i;
                    }
                    else
                    {
                        scoreUI.UpdateStrikes();
                        Destroy(molecule);
                        molecule = null;
                    }
                }
            }

            if (index > -1)
                ordersManager.RemoveOrder(ordersManager.orders[index]);
        }
    }
}
