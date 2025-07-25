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
    static private int lives = 8;
    private static readonly int limitMin = 2;
    private static readonly int limitSec = 0;

    private static readonly bool isDebug = false;
    static private int remainTime = limitMin * 60 + limitSec;
    protected static int approachingPostureLaserRemains = 15;

    public enum TreasureScores
    {
        Gem = 1000, Coin = 100, Cash = 300, Gold = 500,
    };

    static private int score = 0;
    static protected int GetScore()
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
        if (state == GameState.Completed)
        {
            SceneManager.LoadScene("GameClear");
            return;
        }
        if (state == GameState.PlayingPostureLaser || state == GameState.PlayingApproachingPostureLaser)
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
        else if (MathF.Abs(z) <= 8)
        {
            if (GetKinectStat() == KinectStatus.Tracking || isDebug)
            {
                if (approachingPostureLaserRemains > 0)
                {
                    SetGameState(GameState.PlayingApproachingPostureLaser);
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
    }

    static protected void DecreaseApproachingPostureLaserRemainCount()
    {
        approachingPostureLaserRemains--;

        if (approachingPostureLaserRemains == 0)
        {
            SetGameState(GameState.PlayingPostureLaser);
        }
    }
}
