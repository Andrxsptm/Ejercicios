using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEngine3 : MonoBehaviour
{
    public static GameEngine3 Instance;
    public TMP_Text puntosText;
    public int contPuntos;
  
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start() { }

    void Update() { }

    public void SumarPuntos()
    {
        contPuntos += 5;
        puntosText.text = "Puntuacion: " + contPuntos;

           if (contPuntos >= 50)
        {
            SceneManager.LoadScene("Ejercicio4");
        }
    }

    
}