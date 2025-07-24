using UnityEngine;

public class PlayerCollisionDetector : LaserAdventureGame
{
    bool isAlreadyTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        var obj = gameObject.GetComponent<IPlayerCollideAble>();

        if (obj != null && !false && other.gameObject.CompareTag("Player"))
        {
            obj.OnCollideToPlayer();
            isAlreadyTriggered = true;
        }
    }
}
