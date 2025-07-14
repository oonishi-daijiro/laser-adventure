using UnityEngine;



public class LaserAdventureGame : MonoBehaviour
{
    private static LaserAdventureGame instance = new();
    public static LaserAdventureGame Instance { get { return instance; } }

    int lives;
    protected enum GameState
    {
        Yet,
        Playing,
        HMDLaser,
        ApproachingPostureLaser,
        PostureLaser,
        Completed,  
        GameOver
    };
    
    private GameState state = GameState.Playing;

    protected void SetGameState(GameState state)
    {
        Instance.state = state;
    }

    protected void DecreasePlayerLives()
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

    protected int GetPlayerLives()
    {
        return Instance.lives;
    }
}
