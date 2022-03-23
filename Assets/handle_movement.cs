using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle_movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float movementSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, verticalInput * movementSpeed);
    }

}
