using UnityEngine;
using TMPro;
public class GameEngine : MonoBehaviour
{
    public static GameEngine Instance;
    public TMP_Text pasosText;
public TMP_Text pasosIzqText;
public TMP_Text pasosDerText;
    public int contPasos;
    public int contPasosIzq;
    public int contPasosDer;

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

    public void SumarPasos()
    {
        contPasos++;
        pasosText.text = "Pasos: " + contPasos;
    }

    public void SumarPasosIzq()
    {
        contPasosIzq++;
        SumarPasos();
pasosIzqText.text = "Pasos Izq: " + contPasosIzq;
    }

    public void SumarPasosDer()
    {
        contPasosDer++;
        SumarPasos();
pasosDerText.text = "Pasos Der: " + contPasosDer;
    }
}