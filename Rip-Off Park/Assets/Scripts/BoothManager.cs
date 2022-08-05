using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class BoothManager : AbsBoothManager
{
    public bool resetOnStart;
    float highScore = 0;
    float currScore = 0;
    bool isPlaying;

    public UnityEvent Game_Ended;
    public UnityEvent Game_Started;

    public bool isTimedGame;
    public float gameLength = 10f;
    private float timeRemaining = 0;

    public AudioClip gameEndAudio;
    public AudioSource audioSource;

    public Canvas canvas;
    public TMP_Text scoreText;
    public TMP_Text timeLeftText;
    [SerializeField] float playCost;

    public string currScoreMessage = "Current Score: ";
    public string highScoreMessage = "High Score: ";
    private void Start()
    {
        InitBooth();
    }

    public virtual void InitBooth()
    {
        // Called on Start - every inheriting class can add on top of this
        if (audioSource == null)
            audioSource = GetComponentInChildren<AudioSource>();
        audioSource.clip = gameEndAudio;
        UpdateScore();
        ClearClock();
    }

    public virtual void ResetBoothValues()
    {
        ResetCurrScore();
        ClearClock();
    }
    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateClock();
        }
    }

    public override void ResetPressed()
    {
        //this is a Debug button
        On_Reset_Pressed.Invoke();
    }
    public virtual void GameStart()
    {
        //if pressed whilke playing - end game first
        if (IsPlaying())
            GameEnd();
        if(resetOnStart)
            ResetPressed();
        StopAllCoroutines();
        if (isTimedGame)
        {
            timeRemaining = (int)gameLength;
            UpdateClock();
            StartCoroutine(TimedGame());
        }
        Debug.Log("Game Starting: " + gameObject.name);
        SetPlaying(true);
        Game_Started.Invoke();
    }

    public IEnumerator TimedGame()
    {
        yield return new WaitForSeconds(gameLength);
        GameEnd();
    }

    public virtual void GameEnd()
    {

        /*
        This updates the score, signals game ended to all listeners, and resets current score
         */
        Debug.Log("Game Ending: " + gameObject.name);
        UpdateScore();
        StopAllCoroutines();
        //TEMP doesnt have to reset curr score
        ResetCurrScore();
        if (isTimedGame)
            ClearClock();
        SetPlaying(false);
        Game_Ended.Invoke();
        audioSource.PlayOneShot(audioSource.clip);
    }

    public virtual void IncreaseScore(float value)
    {
        float prevScore = currScore;
        currScore += value;
        Debug.Log("Booth: " + gameObject.name +  " Adding score: " + prevScore.ToString() + " -> " + currScore);
        UpdateScore();
    }

    public virtual void DecreaseScore(float value)
    {
        float prevScore = currScore;
        // decrease to value or zero whichever is higher
        currScore = (currScore - value > 0) ? currScore - value : 0;
        Debug.Log("Booth: " + gameObject.name + " Decreasing score: " + prevScore.ToString() + " -> " + GetCurrScore());
        UpdateScore();
    }

    public virtual void UpdateScore()
    {
        //This updates score - ui and highscore
        if (currScore > highScore)
            highScore = currScore;
        scoreText.text = highScoreMessage + ((int)GetHighScore()).ToString() + "\n"
                        + currScoreMessage + ((int)GetCurrScore()).ToString() + "\n";
    }

    public virtual float GetCurrScore()
    {
        return currScore;
    }

    public void SetCurrScore(float value)
    {
        if (value >= 0)
            currScore = value;
        UpdateScore();
    }
    public void ResetCurrScore()
    {
        SetCurrScore(0);
    }

    public bool IsPlaying()
    {
        return isPlaying;
    }

    public void SetPlaying(bool value)
    {
        isPlaying = value;
    }

    public float GetHighScore()
    {
        return highScore;
    }

    public void UpdateClock()
    {
        if(isTimedGame)
            timeLeftText.text = ((int)timeRemaining).ToString();
    }

    public void ClearClock()
    {   
        if(isTimedGame)
            timeLeftText.text = "";
    }








}
