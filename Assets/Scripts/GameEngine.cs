using System.Collections;
using UnityEngine;
using TMPro;

public class GameEngine : MonoBehaviour
{
    public static GameEngine Instance;
    public TMP_Text tiempoText;
    public int contTiempo;
    private Coroutine timerCoroutine;
    private bool timerRunning = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        contTiempo = 0;
        UpdateTiempoText();
        StartTimer();
    }

    public void StartTimer()
    {
        if (timerRunning) return;
        timerCoroutine = StartCoroutine(TimerRoutine());
        timerRunning = true;
    }

    public void StopTimer()
    {
        if (!timerRunning) return;
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
        timerRunning = false;
    }

    public void ResetTimer()
    {
        StopTimer();
        contTiempo = 0;
        UpdateTiempoText();
    }

    private IEnumerator TimerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            contTiempo++;
            UpdateTiempoText();
        }
    }

    private void UpdateTiempoText()
    {
        if (tiempoText != null)
            tiempoText.text = "Tiempo: " + contTiempo + "s";
    }
}
