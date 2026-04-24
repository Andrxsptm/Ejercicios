using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameEngine : MonoBehaviour
{
    public static gameEngine Instance;
    public TMP_Text vidaJugador;
    public TMP_Text vidaEnemigo;
    public int vidasJugador = 5;
    public int vidasEnemigo = 5;

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
        vidaJugador.text = "Vida: " + vidasJugador;
        vidaEnemigo.text = "Vida Enemigo: " + vidasEnemigo;
    }

    void Update() { }

    public void QuitarVidaJugador(Transform jugador, Transform puntoRespawn)
    {
        vidasJugador--;
        vidaJugador.text = "Vida: " + vidasJugador;

        if (vidasJugador <= 0)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else
        {
            jugador.position = puntoRespawn.position;
        }
    }

    public void QuitarVidaEnemigo(GameObject enemigo)
    {
        vidasEnemigo--;
        vidaEnemigo.text = "Vida Enemigo: " + vidasEnemigo;

        if (vidasEnemigo <= 0)
        {
            Destroy(enemigo);
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}