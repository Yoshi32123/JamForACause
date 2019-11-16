using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Different Types of Molecules that can be ordered
public enum Molecule
{
    Water,
    Salt,
    Peroxide,
    Rust,
    Oxygen,
    DryIce,
    BakingSoda,
    Vinegar,
    Milk,
}

public class OrdersManager : MonoBehaviour
{
    #region Camera Fields
    private Camera cam;

    public float CameraHeight
    {
        get
        {
            return 2f * cam.orthographicSize;
        }
    }
    public float CameraWidth
    {
        get
        {
            return CameraHeight * cam.aspect;
        }
    }
    #endregion

    #region Constants
    private const float ORDER_OFFSCREEN_Y = 6.5f;
    private const float ORDER_ONSCREEN_Y = 3.5f;

    private const float ORDER_DISTANCE_FACTOR = 3.2f;
    #endregion

    private float order_starting_x;

    // Prefab of Order GameObject
    public GameObject orderPrefab;

    // List of all orders at play
    private List<GameObject> orders;

    // Current time left until next Order is instantiated
    private float timer;

    // Interval of time between orders (seconds)
    [SerializeField] private float interval = 15;

    // Length of time order is available
    [SerializeField] private float orderLength = 50;

    

    // Start is called before the first frame update
    void Start()
    {
        // Set camera
        cam = Camera.main;

        order_starting_x = CameraWidth / 4 - 0.8f;

        // Initialize list of orders
        orders = new List<GameObject>();

        // Create the first order
        CreateNewOrder();

        // Set timer
        timer = interval;
    }

    void FixedUpdate()
    {
        // Update timer
        timer -= Time.deltaTime;

        // Every time <interval> amount of time passes
        if (timer <= 0)
        {
            // Reset timer
            timer = interval;

            // Add another Order
            CreateNewOrder();
        }
    }

    /// <summary>
    /// Creates a random new order.
    /// </summary>
    /// <returns>The Order GameObject created.</returns>
    private void CreateNewOrder()
    {
        // Instantiate GameObject
        Vector3 startingPosition = new Vector3(order_starting_x - ORDER_DISTANCE_FACTOR * (orders.Count - 1), ORDER_OFFSCREEN_Y);
        GameObject order = Instantiate(orderPrefab, startingPosition, Quaternion.identity);
        // Get Text in Order
        Text orderMoleculeText = order.GetComponentInChildren<Text>();
        // Get Script in Order
        Order orderScript = order.GetComponent<Order>();

        

        // Set starting X equal to the Instantiation position
        orderScript.X = order.transform.position.x;

        // Parent Order to this manager
        order.transform.SetParent(gameObject.transform);

        // Move Y onscreen
        orderScript.Y = ORDER_ONSCREEN_Y;

        // Set Order Timer
        orderScript.lifeSpan = orderLength;
        order.GetComponent<Order>().Timer = orderLength;

        // Number of items in Molecule enum
        int moleculeEnumCount = Enum.GetNames(typeof(Molecule)).Length;
        // Create a random Molecule
        Molecule randomMolecule = (Molecule)UnityEngine.Random.Range(0, moleculeEnumCount);
        // Set Order text to the random Molecule
        orderMoleculeText.text = MoleculeToString(randomMolecule);

        // Add order to list
        orders.Add(order);
    }

    /// <summary>
    /// Removes a specified order.
    /// </summary>
    /// <param name="order">Order to remove.</param>
    public void RemoveOrder(GameObject order)
    {
        // Remove from the list
        orders.Remove(order);

        // Move it back up
        order.GetComponent<Order>().Y = ORDER_OFFSCREEN_Y;

        // Destroy it
        Destroy(order, 2);

        // Shift Orders around
        PositionOrders();
    }

    /// <summary>
    /// Updates Orders position to the right X spot
    /// </summary>
    public void PositionOrders()
    {
        for (int i = 0; i < orders.Count; i++)
        {
            orders[i].GetComponent<Order>().X = order_starting_x - ORDER_DISTANCE_FACTOR * (i - 1);
        }
    }

    /// <summary>
    /// Helper Method. Turns Molecule into string form.
    /// </summary>
    /// <param name="molecule">Molecule to convert.</param>
    /// <returns>String representation of the Molecule.</returns>
    private string MoleculeToString(Molecule molecule)
    {
        switch (molecule)
        {
            case Molecule.Water:
                return "Water";
            case Molecule.Salt:
                return "Salt";
            case Molecule.Peroxide:
                return "Peroxide";
            case Molecule.Rust:
                return "Rust";
            case Molecule.Oxygen:
                return "Oxygen";
            case Molecule.DryIce:
                return "Dry Ice";
            case Molecule.BakingSoda:
                return "Baking Soda";
            case Molecule.Vinegar:
                return "Vinegar";
            case Molecule.Milk:
                return "Milk";
            default:
                return "UntypedMolecule";
        }
    }

    /// <summary>
    /// Checks passed in molecule to see if it matches a current order, updates score/strikes accordingly
    /// </summary>
    /// <param name="molecule"></param>
    /// <returns></returns>
    public bool CheckOrders(GameObject molecule)
    {
        //foreach(GameObject order in orders)
        //{
        //    order.gameObject.
        //}
        return false;
    }

}
