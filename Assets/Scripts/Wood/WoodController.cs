using UnityEngine;

public class WoodController : MonoBehaviour
{
    GameObject Woodcutter;
    public Animator animator;
    Rigidbody2D rb;
    float movement;
    public float movimientoSpeed = 5f;
    public LayerMask capaPiso;
    public bool estaPiso;
    bool saltarPressed;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if (movement > 0f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (movement < 0f)
            transform.localScale = new Vector3(-4, 4, 4);

        animator.SetFloat("velocidadX", Mathf.Abs(movement));

        if (Input.GetKeyDown(KeyCode.Space))
            saltarPressed = true;

        animator.SetBool("piso", estaPiso);
        animator.SetFloat("velocidadY", rb.linearVelocity.y);
    }

    private void FixedUpdate()
    {
        estaPiso = Physics2D.OverlapCircle(
            new Vector2(transform.position.x, transform.position.y - 0.5f),
            0.3f,
            capaPiso
        );

        rb.linearVelocity = new Vector2(movement * movimientoSpeed, rb.linearVelocity.y);

        if (saltarPressed && estaPiso)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 6f);
        }

        saltarPressed = false;
    }

}