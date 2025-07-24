using UnityEngine;

public class LaserHitDetector : MonoBehaviour
{
        [SerializeField] public AudioSource se;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            Debug.Log("カメラ下のカプセルにレーザーが当たりました！");
            se.PlayOneShot(se.clip);
        }
    }
}
