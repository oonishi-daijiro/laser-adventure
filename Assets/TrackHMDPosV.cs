using UnityEngine;

public class TrackHMDPosV : LaserAdventureGame
{
    void Update()
    {
        if (GetGameState() == GameState.PlayingHMDLaser)
        {
            gameObject.transform.position = GetPlayerPos();
        }
    }
}
