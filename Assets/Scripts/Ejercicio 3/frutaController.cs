using UnityEngine;

public class frutaController : MonoBehaviour
{
    public Transform[] puntos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            if (other.CompareTag("wood"))
            {
                GameEngine3.Instance.SumarPuntos();
                MoverAleatorio();
            }
        }
    }

    void MoverAleatorio()
    {
        int indice = Random.Range(0, puntos.Length);
        transform.position = puntos[indice].position;
    }
}
