using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour {

    public enum Difficulty {easy, normal, hard};
    public Difficulty currentDifficulty = Difficulty.easy;

    public float countDown = 60f;

    [SerializeField]
    Canvas inGame;

    [SerializeField]
    Canvas endGame;

    [SerializeField]
    Canvas gameSelect;

    [SerializeField]
    GameObject hider;

    void Start()
    {
        endGame.enabled = false;
        inGame.enabled = false;
        gameSelect.enabled = true;
        hider.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    { 
        if (Input.GetKeyDown("1"))
        {
            currentDifficulty = Difficulty.easy;
            EasyMode();
        }

        if (Input.GetKeyDown("2"))
        {
            currentDifficulty = Difficulty.normal;
            NormalMode();
        }

        if (Input.GetKeyDown("3"))
        {
            currentDifficulty = Difficulty.hard;
            HardMode();
        }

        if (inGame.enabled == true)
        {
            countDown -= Time.deltaTime;

            if (countDown <= 0)
            {
                GameOver();
            }
        }
	}

    private void StartGame()
    {
        endGame.enabled = false;
        inGame.enabled = true;
        gameSelect.enabled = false;
        hider.SetActive(false);
    }

    private void GameOver()
    {
        endGame.enabled = true;
        inGame.enabled = false;
        gameSelect.enabled = false;
        hider.SetActive(false);
    }

    private void AddScore(int scoreToAdd)
    {

        List<BaseTarget> lowPointTargets = new List<BaseTarget>();

        var lowPointTarget = new LowPointTarget();

        lowPointTargets.Add(lowPointTarget);

        foreach (BaseTarget target in lowPointTargets)
        {
            target.score += scoreToAdd;
            Debug.Log(target.score);
        }

        List<BaseTarget> highPointTargets = new List<BaseTarget>();

        var highPointTarget = new HighPointTarget();

        highPointTargets.Add(highPointTarget);

        foreach (BaseTarget target in highPointTargets)
        {
            target.score += scoreToAdd + 2;
            Debug.Log(target.score);
        }
    }

    public void EasyMode()
    {
        countDown = 60f;
        StartGame();
        AddScore(1);
    }

    public void NormalMode()
    {
        countDown = 40;
        StartGame();
        AddScore(2);
    }

    public void HardMode()
    {
        countDown = 30f;
        StartGame();
        AddScore(5);
    }
}
