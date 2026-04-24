using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Animator animator;
    public float movimientoSpeed = 2f;
    Rigidbody2D rb;
    public float distanciaDeteccion = 5f;
    public float distanciaAtaque = 0.8f;
    public Transform objetivo;
    float movement;
    bool atacando = false;
    float cooldownAtaque = 1f;
    float timerAtaque = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (objetivo == null)
            objetivo = GameObject.FindWithTag("wood").transform;
    }

    void Update()
    {
        if (objetivo == null) return;

        float distancia = Vector2.Distance(transform.position, objetivo.position);
        timerAtaque += Time.deltaTime;

        if (distancia <= distanciaAtaque)
        {
            movement = 0f;
            atacando = true;
            animator.SetBool("atacando", true);

            if (timerAtaque >= cooldownAtaque)
            {
                timerAtaque = 0f;
                objetivo.GetComponent<w9>().RecibirDano();
            }
        }
        else if (distancia <= distanciaDeteccion)
        {
            atacando = false;
            animator.SetBool("atacando", false);

            float direccion = objetivo.position.x - transform.position.x;

            if (direccion > 0.1f)
            {
                movement = 1f;
                transform.localScale = new Vector3(3, 3, 3);
            }
            else if (direccion < -0.1f)
            {
                movement = -1f;
                transform.localScale = new Vector3(-3, 3, 3);
            }
        }
        else
        {
            movement = 0f;
            atacando = false;
            animator.SetBool("atacando", false);
        }

        animator.SetFloat("velocidadX", Mathf.Abs(movement));
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement * movimientoSpeed, rb.linearVelocity.y);
    }
}