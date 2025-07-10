using UnityEngine;

public class ApproachingLaser : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        var newPos = gameObject.transform.position;
        newPos.z -= speed;
        gameObject.transform.position = newPos;
        if (gameObject.transform.position.z < -8.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(Quaternion rotation, Vector3 pos, float speed)
    {
        gameObject.transform.rotation = rotation;
        gameObject.transform.position = pos;
        this.speed = speed;
    }
}
