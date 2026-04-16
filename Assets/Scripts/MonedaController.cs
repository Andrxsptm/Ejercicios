using UnityEngine;

public class moneda : MonoBehaviour
{
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
            if(other.CompareTag("wood"))
            {
                GameEngine.Instance.SumarMonedas();
                Destroy(gameObject);
                //ocultar game object
                gameObject.SetActive(false);
                Debug.Log("Si choco");
            }
        }
    }
}
