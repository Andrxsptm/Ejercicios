using UnityEngine;
using TMPro;

public class GameEngine2 : MonoBehaviour
{
    public static GameEngine2 Instance;
    public TMP_Text monedasText;
    public int moneda;
 
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {

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

    public void SumarMonedas()
    {
        moneda++;
        monedasText.text = "Monedas: " + moneda;
    }
}
