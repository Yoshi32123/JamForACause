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
    // Prefab of Order GameObject
    private GameObject orderPrefab;

    // List of all orders at play
    private List<GameObject> orders;

    // Interval of time between orders
    [SerializeField] private float interval;

    // Length of time order is available
    [SerializeField] private float orderLength;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize list of orders
        orders = new List<GameObject>();

        // Create the first order
        CreateNewOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Creates a random new order.
    /// </summary>
    /// <returns>The Order GameObject created.</returns>
    private void CreateNewOrder()
    {
        // Instantiate GameObject
        GameObject order = Instantiate(orderPrefab, Vector3.zero, Quaternion.identity);
        // Get Text in Order
        Text orderMoleculeText = order.GetComponentInChildren<Text>();

        // Number of items in Molecule enum
        int moleculeEnumCount = Enum.GetNames(typeof(Molecule)).Length;
        // Create a random Molecule
        Molecule randomMolecule = (Molecule)UnityEngine.Random.Range(0, moleculeEnumCount);
        // Set Order text to the random Molecule
        orderMoleculeText.text = MoleculeToString(randomMolecule);

        // Add order to list
        orders.Add(order);
    }

    // Turns a Molecule type into a string
    private string MoleculeToString(Molecule molecule)
    {
        switch (molecule)
        {
            case Molecule.Water:
                return "Water";
                break;
            case Molecule.Salt:
                return "Salt";
                break;
            case Molecule.Peroxide:
                return "Peroxide";
                break;
            case Molecule.Rust:
                return "Rust";
                break;
            case Molecule.Oxygen:
                return "Oxygen";
                break;
            case Molecule.DryIce:
                return "Dry Ice";
                break;
            case Molecule.BakingSoda:
                return "Baking Soda";
                break;
            case Molecule.Vinegar:
                return "Vinegar";
                break;
            case Molecule.Milk:
                return "Milk";
                break;
            default:
                return "Molecule";
                break;
        }
    }
}
