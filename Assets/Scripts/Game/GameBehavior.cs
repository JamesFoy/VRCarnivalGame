using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour {

    public float countDown = 60f;

    [SerializeField]
    Canvas inGame;

    [SerializeField]
    Canvas endGame;

    void Start()
    {
        endGame.enabled = false;
        inGame.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0)
        {
            GameOver();
        }
	}

    private void GameOver()
    {
        endGame.enabled = true;
        inGame.enabled = false;
    }
}
