using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool elementSelected = false;
    public GameObject elementStorage;
    public GameObject dish;
    public int[] elements;

    //Formulas
    private int[] waterFormula = new int[] { 0, 2, 0, 1, 0, 0};
    private int[] saltFormula = new int[] { 1, 0, 0, 0, 1, 0};
    private int[] peroxideFormula = new int[] { 0, 2, 0, 2, 0, 0};
    private int[] rustFormula = new int[] { 0, 0, 2, 3, 0, 0};
    private int[] dryIceFormula = new int[] { 0, 0, 0, 2, 0, 1};
    private int[] bakingSodaFormula = new int[] { 0, 1, 0, 3, 1, 1};
    private int[] vinegarFormula = new int[] { 0, 4, 0, 2, 0, 2};
    private int[] milkFormula = new int[] { 0, 6, 0, 3, 0, 3};

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
    void Start()
    {
        elements = new int[] { 0, 0, 0, 0, 0, 0 };
        /*
         index 0: Chlorine
         index 1: Hydrogen
         index 2: Iron
         index 3: Oxygen
         index 4: Sodium
         index 5 : Carbon
         */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckPlacement();
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
        if (elementStorage.tag == "Chlorine")
            elements[0]++;
        else if (elementStorage.tag == "Hydrogen")
            elements[1]++;
        else if (elementStorage.tag == "Iron")
            elements[2]++;
        else if (elementStorage.tag == "Oxygen")
            elements[3]++;
        else if (elementStorage.tag == "Sodium")
            elements[4]++;
        else if (elementStorage.tag == "Carbon")
            elements[5]++;

        Destroy(elementStorage);
    }

    //what kind of return value?
    public bool CheckCombination()
    {
        if (CompareFormulas(elements, waterFormula))
        {
            Instantiate(water, dish.transform.position, Quaternion.identity);
            elements = new int[] { 0, 0, 0, 0, 0, 0 };
            return true;
        }
        else if (CompareFormulas(elements, saltFormula))
        {
            Instantiate(salt, dish.transform.position, Quaternion.identity);
            elements = new int[] { 0, 0, 0, 0, 0, 0 };
            return true;
        }
        else if (CompareFormulas(elements, peroxideFormula))
        {
            Instantiate(peroxide, dish.transform.position, Quaternion.identity);
            elements = new int[] { 0, 0, 0, 0, 0, 0 };
            return true;
        }
        else if (CompareFormulas(elements, rustFormula))
        {
            Instantiate(rust, dish.transform.position, Quaternion.identity);
            elements = new int[] { 0, 0, 0, 0, 0, 0 };
            return true;
        }
        else if (CompareFormulas(elements, dryIceFormula))
        {
            Instantiate(dryIce, dish.transform.position, Quaternion.identity);
            elements = new int[] { 0, 0, 0, 0, 0, 0 };
            return true;
        }
        else if (CompareFormulas(elements, bakingSodaFormula))
        {
            Instantiate(bakingSoda, dish.transform.position, Quaternion.identity);
            elements = new int[] { 0, 0, 0, 0, 0, 0 };
            return true;
        }
        else if (CompareFormulas(elements, vinegarFormula))
        {
            Instantiate(vinegar, dish.transform.position, Quaternion.identity);
            elements = new int[] { 0, 0, 0, 0, 0, 0 };
            return true;
        }
        else if (CompareFormulas(elements, milkFormula))
        {
            Instantiate(milk, dish.transform.position, Quaternion.identity);
            elements = new int[] { 0, 0, 0, 0, 0, 0 };
            return true;
        }
        else
        {
            elements = new int[] { 0, 0, 0, 0, 0, 0 };
            return false;
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
}
