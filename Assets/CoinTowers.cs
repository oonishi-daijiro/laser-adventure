using UnityEngine;

public class CoinTowers : MonoBehaviour
{
    public GameObject target;
    public int row;
    public int col;

    void Start()
    {
        if (target != gameObject && target != null)
        {
            Vector3 size = target.GetComponent<Renderer>().bounds.size;

            var width = size.x;
            var depth = size.z;

            var newPosX = target.transform.position.x;
            var newPosZ = target.transform.position.z;

            for (int i = 0; i < row; i++)
            {
                for (int l = 0; l < col; l++)
                {
                    InstantiateNewCoinTower(newPosX, newPosZ);
                    newPosZ -= depth + 0.005f;
                }
                newPosX += width + 0.005f;
                newPosZ = target.transform.position.z;
            }
        }
    }

    void InstantiateNewCoinTower(float x, float z)
    {
        Vector3 size = target.GetComponent<Renderer>().bounds.size;
        var height = size.y;
        var newPosY = target.transform.position.y;

        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            Instantiate(target, new Vector3(x, newPosY, z), Quaternion.identity, gameObject.transform);
            newPosY += height + 0.005f;
        }
    }

}
