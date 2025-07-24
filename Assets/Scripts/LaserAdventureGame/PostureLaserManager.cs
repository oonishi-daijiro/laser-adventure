using UnityEngine;

public class PostureLaserManager : LaserAdventureGame
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (GetGameState() == GameState.PlayingPostureLaser)
        {
            gameObject.SetActive(true);
        }
    }
}
