using UnityEngine;

public class PlayerCollisionDetector : LaserAdventureGame
{
    bool isAlreadyTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        var obj = gameObject.GetComponent<IPlayerCollideAble>();

        if (obj != null && !isAlreadyTriggered && other.gameObject.CompareTag("Player") && GetGameState() != GameState.Yet)
        {
            obj.OnCollideToPlayer();
            isAlreadyTriggered = true;
            Invoke("ResetIsTriggered", 5);
        }
    }
    void ResetIsTriggered()
    {
        isAlreadyTriggered = false;
    }
}
