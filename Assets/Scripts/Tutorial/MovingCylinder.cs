using UnityEngine;

public class MovingCylinder : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 moveDirection = Vector3.down;  // デフォルト（上書き可）

    void Update()
    {
        transform.position += moveDirection.normalized * speed * Time.deltaTime;
    }
}
