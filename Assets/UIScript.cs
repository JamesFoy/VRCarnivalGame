using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour {

    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    TMP_Text time;

    [SerializeField]
    GameBehavior game;

    public int score = 0;
	
	// Update is called once per frame
	void Update ()
    {
        time.text = "Time Remaining: " + game.countDown;
        scoreText.text = "Score: " + score;
	}
}
