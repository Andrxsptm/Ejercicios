using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text tiempoFinalText;
    float tiempoTranscurrido;
    bool corriendo = true;

    void Update()
    {
        if (!corriendo) return;
        tiempoTranscurrido += Time.deltaTime;
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void DetenerTimer()
    {
        corriendo = false;
        tiempoFinalText.text = "Tiempo Final: " + timerText.text;
        tiempoFinalText.gameObject.SetActive(true);
        StartCoroutine(Reiniciar());
    }

    System.Collections.IEnumerator Reiniciar()
    {
        yield return new WaitForSeconds(2f);
        tiempoTranscurrido = 0f;
        corriendo = true;
        tiempoFinalText.gameObject.SetActive(false);
    }
}