using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = "YOUR SCORE:" + ScoreKeeper.instance.GetScore();
    }

}
