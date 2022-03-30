﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
public class GameCenterLeaderBoard : MonoBehaviour
{
    private ILeaderboard leaderboard;
    private string leaderboard_id = "yourleaderboardid"; // setup on appstore connect

    void Start()
    {

        // Authenticate user first
        Social.localUser.Authenticate(success => {
            if (success)
            {
                Debug.Log("Authentication successful");
                string userInfo = "Username: " + Social.localUser.userName +
                    "\nUser ID: " + Social.localUser.id +
                    "\nIsUnderage: " + Social.localUser.underage;
                Debug.Log(userInfo);
            }
            else
                Debug.Log("Authentication failed");
        });

        // create social leaderboard
        leaderboard = Social.CreateLeaderboard();
        leaderboard.id = leaderboard_id;
        leaderboard.LoadScores(result =>
        {
            Debug.Log("Received " + leaderboard.scores.Length + " scores");
            foreach (IScore score in leaderboard.scores)
                Debug.Log(score);
        });
    }

    public void ReportScore(long score, string leaderboardID)
    {
        score = GameManager.totalScore;
        Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
        Social.ReportScore(score, leaderboardID, success => {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }

    public void OpenLeaderboard()
    {

        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Social.ShowLeaderboardUI();

        }
    }
}
