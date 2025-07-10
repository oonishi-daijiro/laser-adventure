using UnityEngine;

public class TrackRangeContoroller : MonoBehaviour
{
    [SerializeField] public float min;
    [SerializeField] public float max;

    void Update()
    {
        if (!(min < gameObject.transform.position.z && gameObject.transform.position.z < max))
        {
            gameObject.transform.position = new Vector3(0, -10, 0);
        }
    }
}
