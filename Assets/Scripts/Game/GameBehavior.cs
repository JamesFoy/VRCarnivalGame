using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour {

    public enum Difficulty {select, easy, normal, hard};
    public Difficulty currentDifficulty = Difficulty.select;

    public float countDown = 60f;

    [SerializeField]
    AudioSource bellRing;

    [SerializeField]
    Canvas inGame;

    [SerializeField]
    Canvas mapSelect;

    [SerializeField]
    GameObject easyMap;

    [SerializeField]
    GameObject normalMap;

    [SerializeField]
    GameObject hardMap;

    [SerializeField]
    GameObject gameSelectMap;

    [SerializeField]
    GameObject playerZone;

    [SerializeField]
    UIScript uiScript;

    [SerializeField]
    GameObject mapSelectAudio;

    [SerializeField]
    GameObject inGameAudio;

    void Start()
    {
        GameSelect();
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
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }

            if (countDown <= 0)
            {
                bellRing.PlayOneShot(GetComponent<AudioSource>().clip);
            }
        }
	}

    private void StartGame()
    {
        inGameAudio.SetActive(true);
        mapSelectAudio.SetActive(false);
        uiScript.score = 0;
        gameSelectMap.SetActive(false);
        playerZone.SetActive(true);
        inGame.enabled = true;
        mapSelect.enabled = false;
    }

    private void GameSelect()
    {
        mapSelectAudio.SetActive(true);
        inGameAudio.SetActive(false);
        currentDifficulty = Difficulty.select;
        gameSelectMap.SetActive(true);
        playerZone.SetActive(false);
        inGame.enabled = false;
        mapSelect.enabled = true;
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

    public void RestartLevel()
    {
        if (currentDifficulty == Difficulty.easy)
        {
            EasyMode();
        }
        else if (currentDifficulty == Difficulty.normal)
        {
            NormalMode();
        }
        else if (currentDifficulty == Difficulty.hard)
        {
            HardMode();
        }
    }

    public void MapSelection()
    {
        GameSelect();
    }
}
