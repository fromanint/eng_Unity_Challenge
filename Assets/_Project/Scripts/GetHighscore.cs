using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetHighscore : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        string highScore = "Fastest " + PlayerPrefs.GetString("HighScore");
        HighScoreText.text = highScore;
    }

    
}
