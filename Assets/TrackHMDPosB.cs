using UnityEngine;

public class TrackHMDPosB : LaserAdventureGame
{
    void Update()
    {
        if ((GetGameState() == GameState.PlayingPostureLaser || GetGameState() == GameState.PlayingApproachingPostureLaser) && GetKinectStat() == KinectStatus.Tracking)
        {
            gameObject.transform.position = GetPlayerPos();
        }
        else
        {
            gameObject.transform.position = new Vector3(1, -100, 1);
        }

    }
}
