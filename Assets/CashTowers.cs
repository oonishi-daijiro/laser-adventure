using UnityEngine;

public class CashTowers : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        if (target != gameObject && target != null)
        {
            var size = target.GetComponent<Renderer>().bounds.size;
            var newPosZ = target.transform.position.z;

            for (int i = 0; i < 5; i++)
            {
                Instantiate(target, new Vector3(target.transform.position.x, target.transform.position.y, newPosZ), Quaternion.identity, gameObject.transform);
                newPosZ -= size.z + 0.005f;
            }
        }
    }
}
