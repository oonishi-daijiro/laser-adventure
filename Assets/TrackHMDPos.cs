using UnityEngine;

public class TrackHMDPos : MonoBehaviour
{
    public GameObject HMD;

    void Update()
    {
        gameObject.transform.position = HMD.transform.position;    
    }
}
