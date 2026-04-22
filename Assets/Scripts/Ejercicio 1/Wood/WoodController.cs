using UnityEngine;
public class WoodController : MonoBehaviour
{
    GameObject Woodcutter;
    public Animator animator;
    float movement;
    public float movimientoSpeed = 5f;
    Rigidbody2D rb;
    public LayerMask capaPiso;
    public float groundCheckRadius = 0.2f;
    public Transform detectarPiso;
    public bool estaPiso;
    float distanciaAcumuladaIzq;
    float distanciaAcumuladaDer;
   

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        if (movement > 0f)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
        else if (movement < 0f)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }

        animator.SetFloat("velocidadX", Mathf.Abs(movement));

        estaPiso = Physics2D.OverlapCircle(detectarPiso.position, groundCheckRadius, capaPiso);

        if (Input.GetKeyDown(KeyCode.Space) && estaPiso)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 6f);
        }

        animator.SetBool("piso", estaPiso);
        animator.SetFloat("velocidadY", rb.linearVelocity.y);

        if (estaPiso)
        {
            float distancia = Mathf.Abs(movement) * movimientoSpeed * Time.deltaTime;

            if (movement > 0f)
            {
                distanciaAcumuladaDer += distancia;
                while (distanciaAcumuladaDer >= 1.5f)
                {
                    GameEngine.Instance.SumarPasosDer();
                    distanciaAcumuladaDer -= 1.5f;
                }
            }
            else if (movement < 0f)
            {
                distanciaAcumuladaIzq += distancia;
                while (distanciaAcumuladaIzq >= 1.5f)
                {
                    GameEngine.Instance.SumarPasosIzq();
                    distanciaAcumuladaIzq -= 1.5f;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement * movimientoSpeed, rb.linearVelocity.y);
    }
}