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

    void Start()
    {
        endGame.enabled = false;
        inGame.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        RunDifficultySettings();

        if (Input.GetKeyDown("1"))
        {
            currentDifficulty = Difficulty.easy;
        }

        if (Input.GetKeyDown("2"))
        {
            currentDifficulty = Difficulty.normal;
        }

        if (Input.GetKeyDown("3"))
        {
            currentDifficulty = Difficulty.hard;
        }

        countDown -= Time.deltaTime;

        if (countDown <= 0)
        {
            GameOver();
        }
	}

    private void RunDifficultySettings()
    {
        switch (currentDifficulty)
        {
            case Difficulty.easy:
                EasyMode();
                break;
            case Difficulty.normal:
                NormalMode();
                break;
            case Difficulty.hard:
                HardMode();
                break;
        }
    }

    private void GameOver()
    {
        endGame.enabled = true;
        inGame.enabled = false;
    }

    //Test of Polymorphism
    public void EasyMode()
    {
        var lowPointTarget = new LowPointTarget();
        var highPointTarget = new HighPointTarget();

        List<BaseTarget> targets = new List<BaseTarget>();
        targets.Add(lowPointTarget);
        targets.Add(highPointTarget);

        foreach (BaseTarget easyTargets in targets)
        {
            easyTargets.DifficultyScoreChange();
        }
    }

    public void NormalMode()
    {
        var movingLowPointTarget = new MovingLowPointTarget();
        var movingHighPointTarget = new MovingHighPointTarget();

        List<BaseTarget> targets = new List<BaseTarget>();
        targets.Add(movingLowPointTarget);
        targets.Add(movingHighPointTarget);

        foreach (BaseTarget mediumTargets in targets)
        {
            mediumTargets.DifficultyScoreChange();
        }
    }

    public void HardMode()
    {

    }
}
