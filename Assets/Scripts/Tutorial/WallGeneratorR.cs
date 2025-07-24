using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    [Header("壁タイル設定")]
    public GameObject tilePrefab;
    public int tilesWide = 5;           // 横方向（壁の幅）
    public int tilesHigh = 3;           // 縦方向（壁の高さ）
    public float tileSize = 1f;         // タイルの幅と高さ（正方形を想定）

    [Header("壁の位置と向き")]
    public Vector3 centerPosition = Vector3.zero;     // 壁の中心位置
    public Vector3 direction = Vector3.right;         // 横方向の向き（X方向 or Z方向）

    [Header("マテリアル設定")]
    public Material tileMaterial;

    void Start()
    {
        GenerateWall();
    }

    void GenerateWall()
    {
        direction = direction.normalized;

        // 壁の全体サイズ（X/Z方向が width、Yが height）
        float wallWidth = tilesWide * tileSize;
        float wallHeight = tilesHigh * tileSize;

        // 横方向のオフセット（X or Z）
        Vector3 horizontalOffset = direction * (wallWidth / 2f);
        // 縦方向のオフセット（Y）
        Vector3 verticalOffset = Vector3.up * (wallHeight / 2f);

        for (int y = 0; y < tilesHigh; y++)
        {
            for (int x = 0; x < tilesWide; x++)
            {
                // 水平方向の位置（X軸またはZ軸に tileSize ごとに配置）
                Vector3 horizontalPos = direction * (x * tileSize);
                // 垂直方向の位置（Y軸）
                Vector3 verticalPos = Vector3.up * (y * tileSize);
                
                // 合成して最終位置へ（中心基準でオフセット引く）
                Vector3 position = centerPosition + horizontalPos + verticalPos - horizontalOffset - verticalOffset;

                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                tile.name = $"WallTile_{x}_{y}";

                // スケーリング（横方向か奥方向にサイズ調整）
                float xScale = direction.x != 0 ? tileSize : 1;
                float zScale = direction.z != 0 ? tileSize : 1;

                tile.transform.localScale = new Vector3(xScale, tileSize, zScale);

                // マテリアル適用
                Renderer renderer = tile.GetComponent<Renderer>();
                if (renderer != null && tileMaterial != null)
                {
                    renderer.material = tileMaterial;
                }
            }
        }
    }
}
