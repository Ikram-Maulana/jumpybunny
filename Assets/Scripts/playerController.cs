using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float thrust = 10.0f;
    public LayerMask groundLayerMask;
    public Animator animator;
    public float runSpeed = 3f;
    private static playerController sharedInstance;

    private void Awake()
    {
        sharedInstance = this;
    }

    public static playerController GetInstance()
    {
        return sharedInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", true);
    }

    private void FixedUpdate()
    {
        GameState currGameState = GameManager.GetInstance().currentGameState;
        if (currGameState == GameState.InGame)
        {
            if (rigidBody.velocity.x < runSpeed)
            {
                // rigidBody.velocity = new Vector2(x,y);
                rigidBody.velocity = new Vector2(runSpeed, rigidBody.velocity.y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool canJump = GameManager.GetInstance().currentGameState == GameState.InGame;
        bool isOnTheGround = IsOnTheGround();
        animator.SetBool("isGrounded", isOnTheGround);
        if (canJump && (Input.GetMouseButtonDown(0)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.W)
            ) && isOnTheGround)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
        rigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
    }

    bool IsOnTheGround()
    {
        // return Physic2D.Raycast(yang ditransform adalah position, vector2.u/d, jarak ground dan bunny, masukan layerMask.value);
        return Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundLayerMask.value);
    }

    public void KillPlayer()
    {
        animator.SetBool("isAlive", false);
        GameManager.GetInstance().GameOver();
    }
}
