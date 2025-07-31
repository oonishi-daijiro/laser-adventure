using UnityEngine;

public class TrackHMDPosV : LaserAdventureGame
{
    void Update()
    {
        if (GetGameState() == GameState.PlayingHMDLaser)
        {
            gameObject.transform.position = GetPlayerPos();
        }
        // when kinect does not tracking player and playing posture laser.
        else if ((GetGameState() == GameState.PlayingPostureLaser || GetGameState() == GameState.PlayingApproachingPostureLaser) && GetKinectStat() == KinectStatus.OutOfRange)
        {
            gameObject.transform.position = GetPlayerPos();
        }
        else
        {
            gameObject.transform.position = new Vector3(1, -100, 1);
        }
    }
}
