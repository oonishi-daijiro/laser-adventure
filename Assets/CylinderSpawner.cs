using UnityEngine;

public class CylinderSpawner : MonoBehaviour
{
    public GameObject cylinderOriginal;     // シーンに配置しておいた元Cylinder
    public float moveSpeed = 5.0f;          // 移動速度
    public Vector3 spawnPosition = new Vector3(0, 0, 0);  // 発射位置座標

    void Start()
    {
        // 元Cylinderを非表示にしておく（画面に出さない）
        if (cylinderOriginal != null)
        {
            cylinderOriginal.SetActive(false);
        }
    }

    void Update()
    {
        // スペースキーを押したらCylinderを生成
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCylinder();
        }
    }

    void SpawnCylinder()
    {
        if (cylinderOriginal == null) return;

        GameObject newCylinder = Instantiate(cylinderOriginal, spawnPosition, Quaternion.identity);
        newCylinder.SetActive(true);

        // X軸に沿うように回転（デフォルトはY軸方向なのでZ軸90度回転）
        newCylinder.transform.rotation = Quaternion.Euler(0, 0, 90);

        // 移動スクリプトを追加
        MovingCylinder mover = newCylinder.AddComponent<MovingCylinder>();
        mover.speed = moveSpeed;
        mover.moveDirection = Vector3.back; // Z軸マイナス方向へ
    }
}
