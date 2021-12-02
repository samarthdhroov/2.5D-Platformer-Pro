using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _canvasText;

    private void Start()
    {
        if(GetComponentInChildren<Text>() != null)
        {
            _canvasText = GetComponentInChildren<Text>();
            updateCoinScoreDisplay(0); //Calling the method here so that initially, we can see score 0.
        }
    }

    public void updateCoinScoreDisplay(int coin)
    {
        _canvasText.text = "Coins " + coin.ToString(); 
    }
}


