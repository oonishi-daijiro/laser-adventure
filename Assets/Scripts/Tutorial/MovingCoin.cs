using UnityEngine;

public class MovingCoin : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 moveDirection = Vector3.back;

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
