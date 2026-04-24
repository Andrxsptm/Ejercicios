using UnityEngine;
using TMPro;

public class gameEngine2 : MonoBehaviour
{
    public static gameEngine2 Instance;
    public TMP_Text puntosText;
    public int puntos;

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

    void Start()
    {
        puntosText.text = "Puntos: 0";
    }

    void Update() { }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        puntosText.text = "Puntos: " + puntos;
    }
}