using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    public float movimientoSpeed = 2f;
    Rigidbody2D rb;
    public LayerMask capaPiso;
    public float groundCheckRadius = 0.8f;
    public Transform detectarPiso;
    public bool estaPiso;
    public Transform objetivo;
    float movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (objetivo == null)
        {
            objetivo = GameObject.FindWithTag("wood").transform;
        }
    }

    void Update()
    {
        if (objetivo == null) return;

        float distancia = objetivo.position.x - transform.position.x;

        if (distancia > 0.1f)
        {
            movement = 1f;
            transform.localScale = new Vector3(4, 4, 4);
        }
        else if (distancia < -0.1f)
        {
            movement = -1f;
            transform.localScale = new Vector3(-4, 4, 4);
        }
        else
        {
            movement = 0f;
        }

        animator.SetFloat("velocidadX", Mathf.Abs(movement));

        estaPiso = Physics2D.OverlapCircle(detectarPiso.position, groundCheckRadius, capaPiso);
        animator.SetBool("piso", estaPiso);
        animator.SetFloat("velocidadY", rb.linearVelocity.y);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement * movimientoSpeed, rb.linearVelocity.y);
    }
}