using UnityEngine;

public class PlayerCollisionDetector : LaserAdventureGame
{
    bool isAlreadyTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"trigger enter{gameObject.tag} {other.tag}");

        if (other.CompareTag("Player") && gameObject.CompareTag("Laser") && !isAlreadyTriggered)
        {
            Debug.Log("trigger entered with laser and player");
            DecreasePlayerLives();
            isAlreadyTriggered = true;
        }
        else if (other.CompareTag("Player") && gameObject.CompareTag("Treasure"))
        {
            // some socre method needed.
        }
    }
}
