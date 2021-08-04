using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.W)
            
            )
        {
            Jump();
        }
    }

    void Jump()
    {
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
        rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
    }
}