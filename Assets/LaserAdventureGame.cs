using System;
using UnityEngine;

public class LaserAdventureGame : MonoBehaviour
{
    private static LaserAdventureGame _instance = null;
    public static LaserAdventureGame SingletonInstance { get { return _instance; } }
    private GameObject playerBody;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    int lives = 3;
    private int limitMin = 30;
    private int limitSec = 0;

    protected enum GameState
    {
        Yet,
        Playing,
        HMDLaser,
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

    private GameState state = GameState.Playing;
    private KinectStatus kinectStat = KinectStatus.Waiting;

    protected void SetGameState(GameState state)
    {
        if (state == GameState.PlayingPostureLaser)
        {
            if (GetKinectStat() != KinectStatus.Tracking)
            {
                SingletonInstance.state = GameState.Unexpected;
            }
        }
        SingletonInstance.state = state;
    }

    protected GameState GetGameState()
    {
        return state;
    }

    protected void DecreasePlayerLives()
    {
        var lives = GetPlayerLives();

        if (lives - 1 == 0)
        {
            SetGameState(GameState.GameOver);
        }
        else
        {
            SingletonInstance.lives--;
        }
    }

    protected int GetPlayerLives()
    {
        return SingletonInstance.lives;
    }

    protected int GetTimeLimitSec()
    {
        return SingletonInstance.limitMin * 60 + SingletonInstance.limitSec;
    }

    protected void SetKinectStat(KinectStatus status)
    {
        SingletonInstance.kinectStat = status;
    }

    protected KinectStatus GetKinectStat()
    {
        return SingletonInstance.kinectStat;
    }

    protected string GetDebugGameState()
    {
        var gameStateStr = GetGameState().ToString();
        var kinectStateStr = GetKinectStat().ToString();

        return $"gamestete:{gameStateStr} kinectstate:{kinectStateStr}";
    }
}
