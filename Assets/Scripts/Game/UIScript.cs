using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour {

    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    TMP_Text endGameScoreText;

    [SerializeField]
    TMP_Text time;

    [SerializeField]
    GameBehavior game;

    [SerializeField]
    GameObject duringGame;

    [SerializeField]
    GameObject afterGame;

    public int score = 0;

    private void Start()
    {
        duringGame.SetActive(false);
        afterGame.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (game.currentDifficulty != GameBehavior.Difficulty.select)
        {
            duringGame.SetActive(true);
            afterGame.SetActive(false);
            time.text = "Time Remaining: " + (int)game.countDown;
            scoreText.text = "Score: " + score;
        }

        if (game.countDown <= 0)
        {
            afterGame.SetActive(true);
            duringGame.SetActive(false);

            endGameScoreText.text = "Your Score: " + score;
        }
	}
}
