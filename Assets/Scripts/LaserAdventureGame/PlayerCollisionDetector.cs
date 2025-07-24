using UnityEngine;

public class PlayerCollisionDetector : LaserAdventureGame
{
    bool isAlreadyTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Laser") && !isAlreadyTriggered)
        {
            DecreasePlayerLives();
            isAlreadyTriggered = true;
            SoundEffectManager.PlaySoundEffect(SoundEffectManager.SoundEffectKind.LaserCollision);
        }
        else if (other.CompareTag("Player") && gameObject.CompareTag("Treasure"))
        {
            SoundEffectManager.PlaySoundEffect(SoundEffectManager.SoundEffectKind.Cash);
        }
    }
}
