using UnityEngine;

public class CoinSpawner2 : MonoBehaviour
{
    public GameObject coinOriginal;                 // 元Coin（非表示）
    public float moveSpeed = 5.0f;                  // 移動速度
    public Vector3 spawnPosition = new Vector3(0, 0, 0);  // 出現位置

    [Range(0f, 360f)]
    public float rotationAroundX = 0f;              // X軸に対する見た目の回転

    void Start()
    {
        if (coinOriginal != null)
        {
            coinOriginal.SetActive(false);          // 元オブジェクトは非表示
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))            // ← Tキーでスポーン
        {
            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        if (coinOriginal == null) return;

        GameObject newCoin = Instantiate(coinOriginal, spawnPosition, Quaternion.identity);
        newCoin.SetActive(true);

        // X軸に回転（見た目の調整）
        Quaternion rotation = Quaternion.AngleAxis(rotationAroundX, Vector3.right);
        newCoin.transform.rotation = rotation;

        // Rigidbody 対策（物理無効）
        Rigidbody rb = newCoin.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        // Z軸マイナス方向に移動
        MovingCoin mover = newCoin.AddComponent<MovingCoin>();
        mover.speed = moveSpeed;
        mover.moveDirection = Vector3.back;
    }
}
