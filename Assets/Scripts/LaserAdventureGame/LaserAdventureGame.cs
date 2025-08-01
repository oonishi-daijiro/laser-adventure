using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserAdventureGame : MonoBehaviour
{

    static protected readonly int defaultLives = 8;
    static protected readonly Vector3 initialHMDPosition = new(0, 0, -9.5f);
    static protected readonly int limitMin = 3;
    static protected readonly int limitSec = 0;
    static private readonly int approachingPostureLaserCount = 15;

    static private int lives = defaultLives;
    static private Vector3 playerPos;
    static private bool isDebug = false;
    static private int remainTime = limitMin * 60 + limitSec;
    static protected int approachingPostureLaserRemains = approachingPostureLaserCount;



    public enum TreasureScores
    {
        Coin = 100, TwoCoin = 200, ThreeCoin = 300
    };

    static private int score = 0;
    static protected int GetScore()
    {
        return score;
    }

    static protected int GetHighestScore()
    {
        var score = PlayerPrefs.GetInt("HighestScore");
        return score;
    }

    static public void ResetEverything()
    {
        if (score > GetHighestScore())
        {
            PlayerPrefs.SetInt("HighestScore", score);
            PlayerPrefs.Save();
        }

        lives = defaultLives;
        approachingPostureLaserRemains = approachingPostureLaserCount;
        score = 0;
        SetGameState(GameState.Playing);
        SetKinectStat(KinectStatus.OutOfRange);
    }
    static protected void ResetHighestScore()
    {
        PlayerPrefs.SetInt("HighestScore", 0);
        PlayerPrefs.Save();
    }

    protected enum GameState
    {
        Yet,
        Playing,
        PlayingHMDLaser,
        PlayingApproachingPostureLaser,
        PlayingPostureLaser,
        Completed,
        GameOver,
        Unexpected
    };

    protected enum KinectStatus
    {
        Waiting,
        Tracking,
        OutOfRange,
        Error
    };

    static private GameState state = GameState.Playing;
    static private KinectStatus kinectStat = KinectStatus.Waiting;

    static protected void SetGameState(GameState state)
    {
        if (state == GameState.Completed)
        {
            score += GetPlayerLives() * 200;
            SceneManager.LoadScene("GameClear");
            return;
        }
        else if (state == GameState.GameOver)
        {
            score += GetPlayerLives() * 200;
        }
        else if (state == GameState.PlayingPostureLaser || state == GameState.PlayingApproachingPostureLaser)
        {
            if (kinectStat != KinectStatus.Tracking)
            {
                if (!isDebug)
                {
                    LaserAdventureGame.state = GameState.Unexpected;
                    return;
                }
            }
        }
        LaserAdventureGame.state = state;
    }

    static protected void DecreasePlayerLives()
    {
        lives--;
        if (lives == 0)
        {
            SetGameState(GameState.GameOver);
        }
    }

    static protected GameState GetGameState()
    {
        return state;
    }

    static protected int GetPlayerLives()
    {
        return lives;
    }

    static protected int GetTimeLimitSec()
    {
        return limitMin * 60 + limitSec;
    }

    static protected void SetKinectStat(KinectStatus status)
    {
        kinectStat = status;
    }

    static protected KinectStatus GetKinectStat()
    {
        return kinectStat;
    }

    static protected string GetDebugGameState()
    {
        var gameStateStr = state.ToString();
        var kinectStateStr = GetKinectStat().ToString();
        return $"gamestete:{gameStateStr}\n kinectstate:{kinectStateStr}";
    }

    static protected void SetPlayerPos(float x, float y, float z)
    {
        playerPos.x = x;
        playerPos.y = y;
        playerPos.z = z;

        if (GetGameState() == GameState.Playing || GetGameState() == GameState.PlayingHMDLaser || GetGameState() == GameState.PlayingApproachingPostureLaser || GetGameState() == GameState.PlayingPostureLaser)
        {
            if (7 < MathF.Abs(z) && MathF.Abs(z) < 100)
            {
                SetGameState(GameState.PlayingHMDLaser);
            }
            else if (MathF.Abs(z) <= 8)
            {
                if (GetKinectStat() == KinectStatus.Tracking || isDebug)
                {
                    if (approachingPostureLaserRemains > 0)
                    {
                        SetGameState(GameState.PlayingApproachingPostureLaser);
                    }
                    else
                    {
                        SetGameState(GameState.PlayingPostureLaser);
                    }
                }
            }
        }
    }

    static protected Vector3 GetPlayerPos()
    {
        return playerPos;
    }

    static protected void AddScore(TreasureScores gainedScore)
    {
        score += (int)gainedScore;
    }

    static protected void SetRemainTime(int time)
    {
        remainTime = time;
        if (remainTime <= 0 && GetGameState() != GameState.GameOver)
        {
            remainTime = 0;
            SetGameState(GameState.GameOver);
        }
    }

    static protected void DecreaseApproachingPostureLaserRemainCount()
    {
        approachingPostureLaserRemains--;
        if (approachingPostureLaserRemains <= 0)
        {
            approachingPostureLaserRemains = 0;
        }
    }

    static protected void Set2DebugMode()
    {
        isDebug = true;
    }

}
