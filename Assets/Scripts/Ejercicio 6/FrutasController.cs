using UnityEngine;

public class FrutasController : MonoBehaviour
{
    public float tiempoBonus = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wood"))
        {
            gameEngine3.Instance.SumarTiempo(tiempoBonus);
            Debug.Log("+5 segundos");
            Destroy(gameObject);
        }
    }
}
