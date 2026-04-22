using UnityEngine;
using UnityEngine.SceneManagement;

public class metaController : MonoBehaviour
{
    public Transform puntoInicio;
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
         // solo reiniciar el tiempo 
        /*if (other.CompareTag("wood"))
        {
            Timer timer = FindObjectOfType<Timer>();
            timer.DetenerTimer();
            other.transform.position = puntoInicio.position;
        }*/

        // para cambiar la escena
        if (other.CompareTag("wood"))
        {
            if (GameEngine2.Instance.moneda >= 5)
            {
                SceneManager.LoadScene("Ejercicio3");
            }
            else
            {
                Timer timer = FindObjectOfType<Timer>();
                timer.DetenerTimer();
                other.transform.position = puntoInicio.position;
            }
        }
    }

}
