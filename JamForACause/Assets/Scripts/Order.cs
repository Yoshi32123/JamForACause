using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    #region Constants
    private const string GREEN = "#4FF360";
    private const string YELLOW = "#F8C93A";
    private const string RED = "#F1301F";
    #endregion

    // Position of Order Object
    public Vector3 position;

    // Molecule asked by the client
    public Molecule moleculeOrdered;

    // Time left to complete order
    public float Timer { get; set; }

    // Starting time
    public float lifeSpan;

    // Speed at which Object Lerps
    [SerializeField] private float moveSpeed = 0.1f;

    // Timer bar
    private Transform timerBar;
    // Script containing timer bar image properties like color
    private Image barImageScript;

    public float X
    {
        get
        {
            return position.x;
        }
        set
        {
            position = new Vector3(value, position.y, position.z);
        }
    }

    public float Y
    {
        get
        {
            return position.y;
        }
        set
        {
            position = new Vector3(position.x, value, position.z);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the timer bar to scale it appropriately
        timerBar = gameObject.transform.GetChild(2).GetChild(1).GetChild(1);

        // Get timer bar Image Script to recolor
        barImageScript = timerBar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Update Physics
    void FixedUpdate()
    {

        // Smoothly move towards it's position
        transform.position = Vector3.Lerp(transform.position, position, moveSpeed);

        // Update timer
        Timer -= Time.deltaTime;

        // When time runs out, remove this Order
        if (Timer <= 0)
        {
            gameObject.GetComponentInParent<OrdersManager>().RemoveOrder(gameObject);
        }

        // Update Timer Bar size
        UpdateBarSize(Percentage(Timer, lifeSpan));

        // Update Timer Bar color
        UpdateBarColor();
    }

    #region Helper Methods
    /// <summary>
    /// Returns percentage in decimal
    /// between a number and its total it is being
    /// compared to.
    /// </summary>
    /// <param name="part">Current amount.</param>
    /// <param name="total">Total amount to compare.</param>
    /// <returns>Percentage in decimal form.</returns>
    private float Percentage(float amount, float total)
    {
        return amount / total;
    }

    /// <summary>
    /// Sizes timer bar.
    /// </summary>
    /// <param name="percent">Percent the bar is currently at.</param>
    private void UpdateBarSize(float percent)
    {
        timerBar.localScale = new Vector3(percent, timerBar.localScale.y, timerBar.localScale.z);
    }

    /// <summary>
    /// Changes color of timer bar.
    /// </summary>
    /// <param name="hexCode">Hexadecimal code to change color of bar to.</param>
    private void UpdateBarColor()
    {
        Color newColor;
        if (Percentage(Timer, lifeSpan) <= 0.25f)
            ColorUtility.TryParseHtmlString(RED, out newColor);
        else if (Percentage(Timer, lifeSpan) <= 0.5f)
            ColorUtility.TryParseHtmlString(YELLOW, out newColor);
        else
            ColorUtility.TryParseHtmlString(GREEN, out newColor);

        barImageScript.color = newColor;
    }
    #endregion
}
