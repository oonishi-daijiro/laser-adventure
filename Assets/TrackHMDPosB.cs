using UnityEngine;

public class TrackHMDPosB : LaserAdventureGame
{
    void Update()
    {
        if (GetGameState() == GameState.PlayingPostureLaser || GetGameState() == GameState.PlayingApproachingPostureLaser)
        {
            gameObject.transform.position = GetPlayerPos();
        }
    }
}
