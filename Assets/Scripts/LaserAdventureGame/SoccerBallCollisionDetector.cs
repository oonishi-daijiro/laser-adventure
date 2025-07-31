using UnityEngine;

public class SoccerBallCollisionDetector : LaserAdventureGame
{

    void OnTriggerEnter(Collider other)
    {
        var obj = gameObject.GetComponent<ISoccerBallColideAble>();

        if (obj != null  && other.gameObject.CompareTag("SoccerBall") && GetGameState() != GameState.Yet)
        {
            obj.OnCollideToBall();
        }
    }
}
