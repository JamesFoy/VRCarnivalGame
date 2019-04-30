using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Game;

//Author - James Foy
//This script is used for all of the UI elements within the game. It controls updating the UI when certain actions 
//by the player are completed like hitting targets

namespace UI
{
    public class UIScript : MonoBehaviour
    {

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

        [SerializeField]
        AudioSource bellRing;

        public int score = 0;

        private void Start()
        {
            duringGame.SetActive(false);
            afterGame.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            //checks if the current difficulty is not map selection
            if (game.currentDifficulty != GameBehavior.Difficulty.select)
            {
                duringGame.SetActive(true);
                afterGame.SetActive(false);
                time.text = "Time Remaining: " + (int)game.countDown;
                scoreText.text = "Score: " + score;
            }

            //information to display when the countdown reaches 0
            if (game.countDown <= 0)
            {
                afterGame.SetActive(true);
                duringGame.SetActive(false);

                endGameScoreText.text = "Your Score: " + score;
            }
        }
    }
}
