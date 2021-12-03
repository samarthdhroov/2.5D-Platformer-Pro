using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _canvasText;

    [SerializeField]
    private Text _livesText;

    private void Start()
    {
        updateCoinScoreDisplay(0); //Calling the method here so that initially, we can see score 0.
    }

    public void updateCoinScoreDisplay(int coin)
    {
        _canvasText.text = "Coins " + coin.ToString(); 
    }

    public void updateLivesText(int lives)
    {
        _livesText.text = "Lives " + lives.ToString();
    }
}


