using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Targets;
using UI;

//Author - James Foy (Foy14355306)
//This script is used to control all of the game behaviour like map selection and difficulties

namespace Game
{
    public class GameBehavior : MonoBehaviour
    {

        public enum Difficulty { select, easy, normal, hard };
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

        // Update is called once per frame. These are used to help test each mode
        void Update()
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

            //starts the countdown when the player is in the game
            if (inGame.enabled == true)
            {
                if (countDown > 0)
                {
                    countDown -= Time.deltaTime;
                }
            }
        }

        //Actions to take when the game starts. Sets specific maps and variables like the ui score to 0
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

        //Actions to take when the player is in map selection. Sets specific maps to on/off
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

        //This is used to add a specific amount to how much score each target gives the player depending on the difficutly
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

        //All of the actions to take if the player choses easy mode. Sets the map, countdown timer and amount of score each target adds
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

        //All of the actions to take if the player choses normal mode. Sets the map, countdown timer and amount of score each target adds
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

        //All of the actions to take if the player choses hard mode. Sets the map, countdown timer and amount of score each target adds
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

        //Actions to take when the player choses to restart the current map/difficulty
        public void RestartLevel()
        {
            if (currentDifficulty == Difficulty.easy)
            {
                EasyMode();
                ResetTargets();
            }
            else if (currentDifficulty == Difficulty.normal)
            {
                NormalMode();
                ResetTargets();
            }
            else if (currentDifficulty == Difficulty.hard)
            {
                HardMode();
                ResetTargets();
            }
        }

        //Makes the player move to map selection
        public void MapSelection()
        {
            GameSelect();
        }

        public void ResetTargets()
        {
            //Resets Dropped Targets when the countdown ends
            BaseTarget[] lowPointTargets;

            var lowPointTarget = new LowPointTarget();

            lowPointTargets = GameObject.FindObjectsOfType<LowPointTarget>();

            foreach (BaseTarget target in lowPointTargets)
            {
                target.targetCollider.enabled = true;
                target.anim.SetTrigger("ResetTarget");
            }

            BaseTarget[] highPointTargets;

            var highPointTarget = new HighPointTarget();

            highPointTargets = GameObject.FindObjectsOfType<HighPointTarget>();

            foreach (BaseTarget target in highPointTargets)
            {
                target.targetCollider.enabled = true;
                target.anim.SetTrigger("ResetTarget");
            }
        }
    }
}

