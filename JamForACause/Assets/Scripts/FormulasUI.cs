using UnityEngine;

public class FormulasUI : MonoBehaviour
{
    #region Constants
    private const float ONSCREEN_Y = 50;
    private const float OFFSCREEN_Y = -925f;
    #endregion

    // Position of Order Object
    public Vector3 position;

    // Whether formula sheet is on screen
    private bool display;

    // Speed at which Object Lerps
    [SerializeField] private float moveSpeed;

    // Container of formula sheet
    private GameObject formulasContainer;

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
        // Set display
        display = false;

        // Get container
        formulasContainer = GameObject.FindGameObjectWithTag("FormulasContainer");

        // Set starting position
        position = new Vector3(0, OFFSCREEN_Y, 0);
        formulasContainer.transform.position = position;
    }

    // Update Physics
    void FixedUpdate()
    {
        // Set Y position
        if (display)
            Y = ONSCREEN_Y;
        else
            Y = OFFSCREEN_Y;

        // Smoothly move towards it's position
        formulasContainer.transform.localPosition = Vector3.Lerp(formulasContainer.transform.localPosition, position, moveSpeed);
    }

    /// <summary>
    /// Toggles position of formula sheet
    /// between offscren and onscreen
    /// </summary>
    public void TogglePosition()
    {
        display = !display;
    }
}
