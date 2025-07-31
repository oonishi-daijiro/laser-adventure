using UnityEngine;

public class PlayerCollisionDetector : LaserAdventureGame
{
    bool isAlreadyTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        var plObj = gameObject.GetComponent<IPlayerCollideAble>();

        if (plObj != null && !isAlreadyTriggered && other.gameObject.CompareTag("Player") && GetGameState() != GameState.Yet)
        {
            plObj.OnCollideToPlayer();
            isAlreadyTriggered = true;
            Invoke(nameof(ResetIsTriggered), 5);
        }
        
    }
    void ResetIsTriggered()
    {
        isAlreadyTriggered = false;
    }
}
