using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    [SerializeField] public AudioSource cashSE;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Player"))
        {
            cashSE.PlayOneShot(cashSE.clip);
        }
    }

}
