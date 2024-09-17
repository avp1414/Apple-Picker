/*******************************************************************
* COPYRIGHT       : 2024
* PROJECT         : Assignment 01 - Apple Picker .
* FILE NAME       : HighScore.cs
* DESCRIPTION     : Manages the HighScore functionality.
*                    
* REVISION HISTORY:
* Date 			Author    		        Comments
* ---------------------------------------------------------------------------
* 2024/07/17	Akram Taghavi-Burris    Created.
* 2024/09/16    Aaron Phung             Refractored.
*
/******************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    static private TMP_Text _UI_TEXT;
    static private int _SCORE = 1000;

    private TMP_Text txtCom;  // txtCom is a reference to this GO’s TMP_Text component

    //Awake is called once at initalization
    void Awake()
    {
        _UI_TEXT = GetComponent<TMP_Text>();

        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", SCORE);
    }//end Awake()

    //Read-Only proeprty
    static public int SCORE
    {
        get { return _SCORE; }
        private set
        {
            //set score value
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);

            if (_UI_TEXT != null)
            {
                //Set HighScore text to UI
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }//end if (_UI_TEXT != null)
        }//end set
    }//end Score get/set

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= SCORE) return; // If scoreToTry is too low, return
        SCORE = scoreToTry;
    }//end TRY_SET_HIGH_SCORE()

    // The following code allows you to easily reset the PlayerPrefs HighScore
    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    //OnDrawGizmos is called everytime GameObejcts are rendered on screen
    void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore rest to 1,000");
        }
    }//end OnDrawGizmos()
}
