using UnityEngine;

public class PlayerCollisionDetector : LaserAdventureGame
{
    [SerializeField] public AudioSource se;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            se.PlayOneShot(se.clip);
            DecreasePlayerLives();
        }
    }

}
