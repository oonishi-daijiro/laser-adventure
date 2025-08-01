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
            Invoke(nameof(Set2DefaultPos), 5);
        }
    }
    void Set2DefaultPos()
    {
        gameObject.transform.position = defaultPos;
    }
}
