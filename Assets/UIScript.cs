using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour {

    [SerializeField]
    TMP_Text scoreText;

    public int score = 0;
	
	// Update is called once per frame
	void Update ()
    {
        scoreText.text = "Score: " + score;
	}
}
