using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField] float moveSpeed = 0.5f;
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
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = Vector2.Lerp(this.transform.position, mousePosition, moveSpeed);
    }
}
