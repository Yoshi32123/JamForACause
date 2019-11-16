using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private Vector3 position;

    [SerializeField] private float moveSpeed;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
