using UnityEngine;

public class PostureLaserManager : LaserAdventureGame
{
    Vector3 defaultPos;

    void Start()
    {
        defaultPos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(0, -200, 0);
    }

    void Update()
    {
        if (GetGameState() == GameState.PlayingPostureLaser)
        {
            gameObject.transform.position = defaultPos;
        }
    }
}
