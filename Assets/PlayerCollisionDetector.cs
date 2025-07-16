using UnityEngine;

public class PlayerCollisionDetector : LaserAdventureGame
{
    [SerializeField] public AudioSource se;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Laser"))
        {
            se.PlayOneShot(se.clip);
            DecreasePlayerLives();
        }
        else if (other.CompareTag("Player") && gameObject.CompareTag("Treasure"))
        {
            se.PlayOneShot(se.clip);
            // some socre method needed.
        }

    }

}
