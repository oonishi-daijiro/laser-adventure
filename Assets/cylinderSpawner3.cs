using UnityEngine;

public class CylinderSpawner3 : MonoBehaviour
{
    public GameObject cylinderOriginal;        // 元Cylinder（非表示）
    public float moveSpeed = 5.0f;             // 移動速度
    public Vector3 spawnPosition = new Vector3(0, 0, 0);  // 出現位置

    [Range(0f, 360f)]
    public float rotationAroundZ = 0f;         // Z軸に垂直な見た目の回転

    void Start()
    {
        if (cylinderOriginal != null)
        {
            cylinderOriginal.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnCylinder();
        }
    }

    void SpawnCylinder()
    {
        if (cylinderOriginal == null) return;

        GameObject newCylinder = Instantiate(cylinderOriginal, spawnPosition, Quaternion.identity);
        newCylinder.SetActive(true);

        // Y軸→X軸へ回転（Z軸90度でX軸に平行に伸ばす）
        Quaternion baseRotation = Quaternion.Euler(0, 0, 90);

        // Z軸（ワールド）回転でXY平面内の方向を調整（見た目のみ）
        Quaternion rotationOffset = Quaternion.AngleAxis(rotationAroundZ, Vector3.forward);

        // 合成：Z軸に垂直な方向に回転されたX軸平行の円柱
        newCylinder.transform.rotation = rotationOffset * baseRotation;

        // Rigidbody対策（重力無効、物理無効）
        Rigidbody rb = newCylinder.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        // Z軸マイナス方向に固定で移動
        MovingCylinder mover = newCylinder.AddComponent<MovingCylinder>();
        mover.speed = moveSpeed;
        mover.moveDirection = Vector3.back;
    }
}
