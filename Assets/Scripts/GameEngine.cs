using UnityEngine;
using TMPro;

public class GameEngine : MonoBehaviour
{

    public static GameEngine Instance;
    public TMP_Text pasosText;
    public int contPasos;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
     public void SumarPasos()
    {
        contPasos++;
        pasosText.text = "Pasos: " + contPasos;
    }
}
