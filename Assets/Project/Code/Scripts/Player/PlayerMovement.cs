using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector2 movement;

    private Rigidbody2D rb;
    private Animator anim;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        rb.linearVelocity = movement * speed;

        anim.SetFloat(horizontal, movement.x);
        anim.SetFloat(vertical, movement.y);

        if (movement != Vector2.zero)
        {
            anim.SetFloat(lastHorizontal, movement.x);
            anim.SetFloat(lastVertical, movement.y);
        }
    }
}
