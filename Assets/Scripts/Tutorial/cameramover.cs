using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A(-1)～D(+1) or ←→
        float v = Input.GetAxis("Vertical");   // S(-1)～W(+1) or ↑↓

        // 上下移動（矢印 ↑↓ キー）
        float y = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y += 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            y -= 1f;
        }

        // 移動ベクトル（前後左右 + 上下）
        Vector3 move = (transform.forward * v + transform.right * h + Vector3.up * y).normalized;

        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
