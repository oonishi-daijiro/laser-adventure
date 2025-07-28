using UnityEngine;

public class HMDLaserManager : LaserAdventureGame
{
    private Vector3 defaultPos;
    void Start()
    {
        defaultPos = gameObject.transform.position;
    }

    void Update()
    {
        if (GetGameState() == GameState.PlayingHMDLaser)
        {
            gameObject.transform.position = defaultPos;
        }
        else
        {
            gameObject.transform.position = new Vector3(0, -100, 0);
        }
    }
}
