using UnityEngine;

public class RoofGenerator : MonoBehaviour
{
    [Header("屋根タイル設定")]
    public GameObject tilePrefab;
    public int tilesX = 10;             // 横方向（X軸）のタイル数
    public int tilesZ = 10;             // 奥方向（Z軸）のタイル数
    public float tileSize = 1f;         // タイルの幅・奥行き
    public float heightY = 6f;          // 屋根の高さ（Y座標）

    [Header("屋根の中心位置")]
    public Vector3 centerPosition = Vector3.zero;     // 中心のX,Z位置を指定（YはheightYで固定）

    [Header("マテリアル設定")]
    public Material tileMaterial;

    void Start()
    {
        GenerateRoof();
    }

    void GenerateRoof()
    {
        float totalWidth = tilesX * tileSize;
        float totalDepth = tilesZ * tileSize;

        // XZ平面で中心配置
        Vector3 offset = new Vector3(totalWidth / 2f, 0f, totalDepth / 2f);

        for (int x = 0; x < tilesX; x++)
        {
            for (int z = 0; z < tilesZ; z++)
            {
                Vector3 tilePosition = new Vector3(x * tileSize, heightY, z * tileSize);
                tilePosition += new Vector3(centerPosition.x, 0f, centerPosition.z) - offset;

                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity, transform);
                tile.name = $"RoofTile_{x}_{z}";

                // スケール調整
                Vector3 originalScale = tile.transform.localScale;
                tile.transform.localScale = new Vector3(tileSize, originalScale.y, tileSize);

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
