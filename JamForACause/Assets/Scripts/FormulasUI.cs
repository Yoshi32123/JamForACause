using UnityEngine;

public class FormulasUI : MonoBehaviour
{
    #region Constants
    private const float ONSCREEN_Y = 100;
    private const float OFFSCREEN_Y = -925f;
    #endregion

    // Position of Order Object
    public Vector3 position;

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
        // Get container
        formulasContainer = GameObject.FindGameObjectWithTag("FormulasContainer");

        // Set starting position
        position = new Vector3(0, OFFSCREEN_Y, 0);
        formulasContainer.transform.position = position;
    }

    // Update Physics
    void FixedUpdate()
    {
        // Smoothly move towards it's position
        formulasContainer.transform.position = Vector3.Lerp(formulasContainer.transform.position, position, moveSpeed);
    }

    /// <summary>
    /// Toggles position of formula sheet
    /// between offscren and onscreen
    /// </summary>
    public void TogglePosition()
    {
        if (Y == OFFSCREEN_Y)
            Y = ONSCREEN_Y;
        else if (Y == ONSCREEN_Y)
            Y = OFFSCREEN_Y;
    }
}
