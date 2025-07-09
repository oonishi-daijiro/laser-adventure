using UnityEngine;

public class PileOfGem : MonoBehaviour
{
    public GameObject target;

    public float range;

    void Start()
    {
        if (target != gameObject && target != null)
        {
            for (int i = 0; i < 20; i++)
            {
                var randomPosX = target.transform.position.x + (range * Mathf.Cos(RandomAngle()));
                var randomPosZ = target.transform.position.z + (range * Mathf.Sin(RandomAngle()));
                var randomRotQuat = Quaternion.Euler(RandomAngle(), RandomAngle(), RandomAngle());
                Instantiate(target, new Vector3(randomPosX, target.transform.position.y, randomPosZ), randomRotQuat, gameObject.transform);
            }
        }

    }

    public float RandomAngle()
    {
        return Random.Range(0, 360);
    }
}
