using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class buddycontroller : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Animator animator;

    private Vector2 input;

    public float speed = 1;

    private float idleThreshold = 0.001f;

    private Vector2 lastDirection = Vector2.zero;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = input * speed;
        Vector2 v = rigidBody.linearVelocity;

        bool isMoving = v.magnitude > idleThreshold;

        if (isMoving == true)
        {
            lastDirection = v;
        }

        if (animator != null) 
            {
             animator.SetFloat("Horizontal", input.x);
            animator.SetFloat("Vertical", input.y);

        }
    }

}


