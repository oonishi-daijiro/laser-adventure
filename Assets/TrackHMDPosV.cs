using UnityEngine;

public class TrackHMDPosV : LaserAdventureGame
{
    void Update()
    {
        if (GetGameState() == GameState.PlayingHMDLaser)
        {
            gameObject.transform.position = GetPlayerPos();
        }
        else
        {
            gameObject.transform.position = new Vector3(1, 100, 1);
        }
    }
}
