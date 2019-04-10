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

    [SerializeField]
    GameObject easyMap;

    [SerializeField]
    GameObject normalMap;

    [SerializeField]
    GameObject hardMap;

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
            EasyMode();
        }

        if (Input.GetKeyDown("2"))
        {
            NormalMode();
        }

        if (Input.GetKeyDown("3"))
        {
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

    private void GameSelect()
    {
        endGame.enabled = false;
        inGame.enabled = false;
        gameSelect.enabled = true;
        hider.SetActive(true);
    }

    private void AddScore(int scoreToAdd)
    {

        BaseTarget[] lowPointTargets;

        var lowPointTarget = new LowPointTarget();

        lowPointTargets = GameObject.FindObjectsOfType<LowPointTarget>();

        foreach (BaseTarget target in lowPointTargets)
        {
            target.score += scoreToAdd;
            Debug.Log(target.score);
        }

        BaseTarget[] highPointTargets;

        var highPointTarget = new HighPointTarget();

        highPointTargets = GameObject.FindObjectsOfType<HighPointTarget>();

        foreach (BaseTarget target in highPointTargets)
        {
            target.score += scoreToAdd + 2;
            Debug.Log(target.score);
        }
    }

    public void EasyMode()
    {
        currentDifficulty = Difficulty.easy;
        countDown = 60f;
        StartGame();
        easyMap.SetActive(true);
        normalMap.SetActive(false);
        hardMap.SetActive(false);
        AddScore(1);
    }

    public void NormalMode()
    {
        currentDifficulty = Difficulty.normal;
        countDown = 40;
        StartGame();
        easyMap.SetActive(false);
        normalMap.SetActive(true);
        hardMap.SetActive(false);
        AddScore(2);
    }

    public void HardMode()
    {
        currentDifficulty = Difficulty.hard;
        countDown = 30f;
        StartGame();
        easyMap.SetActive(false);
        normalMap.SetActive(false);
        hardMap.SetActive(true);
        AddScore(5);
    }
}
