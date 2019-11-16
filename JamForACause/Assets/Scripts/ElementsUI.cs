using UnityEngine;
using UnityEngine.UI;

public class ElementsUI : MonoBehaviour
{
    // Pointer to the camera script's array of elements
    private int[] elementsInDish;
    // Pointer to array of text of elements in UI
    private Text[] elementsText; 

    // Start is called before the first frame update
    void Start()
    {
        // Get array count of elements
        elementsInDish = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>().elements;

        // Get array of of Text Objects in UI
        elementsText = GameObject.FindGameObjectWithTag("ElementsList").GetComponentsInChildren<Text>();

        Debug.Log(elementsInDish.Length);
        Debug.Log(elementsText.Length);
    }

    // Update is called once per frame
    void Update()
    {
        // Update Text in UI
        for (int i = 0; i < elementsText.Length; i++)
        {
            string elementInitial = ElementToInitial(elementsText[i].gameObject.name);
            string elementName = elementsText[i].gameObject.name;

            elementsText[i].text = $"({elementInitial}) {elementName} : {elementsInDish[i]}";
        }
    }

    /// <summary>
    /// Converts element name to its initial.
    /// </summary>
    /// <param name="element">Element name.</param>
    /// <returns>Initial of specified element.</returns>
    private string ElementToInitial(string element)
    {
        switch (element)
        {
            case "Hydrogen":
                return "H";
            case "Oxygen":
                return "O";
            case "Iron":
                return "Fe";
            case "Sodium":
                return "Na";
            case "Chlorine":
                return "Cl";
            case "Carbon":
                return "C";
            default:
                return "null";
        }
    }
}
