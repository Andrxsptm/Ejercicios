using UnityEngine;
 
public class w9 : MonoBehaviour
{
    public Animator animator;
    public float movimientoSpeed = 2f;
    Rigidbody2D rb;
    public LayerMask capaPiso;
    public float groundCheckRadius = 0.8f;
    public Transform detectarPiso;
    public bool estaPiso;
    public Transform puntoRespawn;
    float movement;
    bool atacando = false;
 
    // --- NUEVO: cooldown para que el daño no se aplique cada frame ---
    public float cooldownAtaque = 0.5f;
    float timerAtaque = 0f;
 
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
 
        estaPiso = Physics2D.OverlapCircle(detectarPiso.position, groundCheckRadius, capaPiso);
 
        if (Input.GetKeyDown(KeyCode.UpArrow) && estaPiso)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 6f);
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            atacando = true;
            animator.SetBool("atacando", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            atacando = false;
            animator.SetBool("atacando", false);
        }
 
        animator.SetBool("piso", estaPiso);
        animator.SetFloat("velocidadY", rb.linearVelocity.y);
 
        // Acumular tiempo siempre
        timerAtaque += Time.deltaTime;
 
        if (atacando && timerAtaque >= cooldownAtaque)
        {
            timerAtaque = 0f; // Resetear cooldown al golpear
 
            Collider2D[] enemigos = Physics2D.OverlapCircleAll(transform.position, 1.3f);
            foreach (Collider2D col in enemigos)
            {
                if (col.CompareTag("enemy"))
                {
                    gameEngine.Instance.QuitarVidaEnemigo(col.gameObject);
                }
            }
        }
    }
 
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement * movimientoSpeed, rb.linearVelocity.y);
    }
 
    public void RecibirDano()
    {
        gameEngine.Instance.QuitarVidaJugador(transform, puntoRespawn);
    }
}
 