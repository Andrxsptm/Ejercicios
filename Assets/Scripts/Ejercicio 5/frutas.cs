using UnityEngine;

public class frutas : MonoBehaviour
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
        if (other != null && other.CompareTag("wood"))
        {
            int puntos = 0;

            if (gameObject.CompareTag("uva"))
                puntos = 5;
            else if (gameObject.CompareTag("fresa"))
                puntos = 2;
            else if (gameObject.CompareTag("piña"))
                puntos = 10;
            else if (gameObject.CompareTag("pera"))
                puntos = 4;

            if (puntos > 0)
            {
                gameEngine2.Instance.SumarPuntos(puntos);
                Debug.Log($"Fruta recogida: {gameObject.tag} | +{puntos} puntos");
                Destroy(gameObject);
            }
        }
    }
    
}
