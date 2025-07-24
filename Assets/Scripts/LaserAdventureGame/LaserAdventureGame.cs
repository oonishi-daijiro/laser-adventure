using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaserAdventureGame : MonoBehaviour
{

    public enum SEKinds
    {
        LaserColl,
        Cash
    }

    static private Vector3 playerPos;
    static private int lives = 1500;
    static private int limitMin = 30;
    static private int limitSec = 0;

    static private bool isDebug = true;

    public enum TreasureScores
    {
        Gem = 1000, Coin = 100, Cash = 300, Gold = 500,
    };

    static private int score = 0;
    static protected int getScore()
    {
        return score;
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
        if (state == GameState.PlayingPostureLaser)
        {
            if (kinectStat != KinectStatus.Tracking)
            {
                state = GameState.Unexpected;
            }
        }
        LaserAdventureGame.state = state;
    }

    static protected void DecreasePlayerLives()
    {
        if (lives - 1 == 0)
        {
            SetGameState(GameState.GameOver);
        }
        else
        {
            lives--;
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

        if (7 < MathF.Abs(z) && MathF.Abs(z) < 100)
        {
            SetGameState(GameState.PlayingHMDLaser);
        }
        else if (MathF.Abs(z) <= 7)
        {
            if (GetKinectStat() == KinectStatus.Tracking || isDebug)
            {
                SetGameState(GameState.PlayingApproachingPostureLaser);
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
}
