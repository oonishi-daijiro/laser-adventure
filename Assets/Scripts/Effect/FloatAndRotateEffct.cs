using UnityEngine;

public class FloatAndRotateEffect : MonoBehaviour
{
    public float speed = 1.0f;          // 回転スピード
    public float amplitude = 0.01f;     // 上下振動の振幅
    public float period = 3.0f;         // 上下振動の周期

    public enum RotationAxis
    {
        X,
        Y,
        Z
    }

    public RotationAxis rotationAxis = RotationAxis.Y;  // デフォルトはY軸

    private Vector3 startPos;   // 初期位置

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Rotate();
        FloatUpDown();
    }

    void Rotate()
    {
        Vector3 axis;

        switch (rotationAxis)
        {
            case RotationAxis.X:
                axis = Vector3.right;
                break;
            case RotationAxis.Y:
                axis = Vector3.up;
                break;
            case RotationAxis.Z:
                axis = Vector3.forward;
                break;
            default:
                axis = Vector3.up;
                break;
        }

        transform.Rotate(axis * speed * Time.deltaTime);
    }

    void FloatUpDown()
    {
        float frequency = 1.0f / period;
        float yOffset = amplitude * Mathf.Sin(2.0f * Mathf.PI * frequency * Time.time);
        transform.position = startPos + new Vector3(0, yOffset, 0);
    }
}
