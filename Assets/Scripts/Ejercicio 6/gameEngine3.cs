using UnityEngine;
using TMPro;

public class gameEngine3 : MonoBehaviour
{
    public static gameEngine3 Instance;

    public TMP_Text tiempoText;
    public TMP_Text gameOverText;


    public float tiempoRestante = 30f;
    private bool juegoTerminado = false;

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
        gameOverText.gameObject.SetActive(false);
        ActualizarTemp();
    }

    void Update()
    {
        if (juegoTerminado) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            tiempoRestante = 0f;
            GameOver();
        }

        ActualizarTemp();
    }

    public void SumarTiempo(float segundos)
    {
        if (!juegoTerminado)
            tiempoRestante += segundos;
    }

    private void ActualizarTemp()
    {
        tiempoText.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante);
    }

    private void GameOver()
    {
        juegoTerminado = true;
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "¡Perdiste!";
        Time.timeScale = 0f; // pausa el juego
    }
}