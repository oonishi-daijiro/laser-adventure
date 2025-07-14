using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [Header("床タイル設定")]
    public GameObject tilePrefab;
    public int tilesX = 10;             // X方向（幅）のタイル数
    public int tilesZ = 10;             // Z方向（奥行き）のタイル数
    public float tileSize = 1f;         // タイルのサイズ（正方形を想定）

    [Header("床の位置")]
    public Vector3 centerPosition = Vector3.zero;   // 床全体の中心位置

    [Header("マテリアル設定")]
    public Material tileMaterial;

    void Start()
    {
        GenerateFloor();
    }

    void GenerateFloor()
    {
        float totalWidth = tilesX * tileSize;
        float totalDepth = tilesZ * tileSize;

        // オフセットで中心揃え
        Vector3 offset = new Vector3(totalWidth / 2f, 0f, totalDepth / 2f);

        for (int x = 0; x < tilesX; x++)
        {
            for (int z = 0; z < tilesZ; z++)
            {
                Vector3 tilePosition = centerPosition + new Vector3(x * tileSize, 0f, z * tileSize) - offset;

                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity, transform);
                tile.name = $"FloorTile_{x}_{z}";

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
