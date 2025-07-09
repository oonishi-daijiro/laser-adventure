using System.Numerics;
using UnityEngine;

public class GoldStack : MonoBehaviour
{
    public GameObject target;
    public float marginX;

    void Start()
    {
        if (target != gameObject && target != null)
        {
            UnityEngine.Vector3 size = target.GetComponent<Renderer>().bounds.size;
            var width = size.x;
            var height = size.y;

            var newPosX = target.transform.position.x + width + marginX;
            var newPosY = target.transform.position.y;

            // puts target object with layout of pyramid

            for (int i = 0; i < 5; i++)
            {
                for (int l = 0; l < 5 - (i == 0 ? 1 : i); l++)
                {
                    Instantiate(target, new UnityEngine.Vector3(newPosX, newPosY, target.transform.position.z), target.transform.rotation, gameObject.transform);
                    newPosX += marginX + width;
                }
                newPosY += height + 0.005f;
                newPosX = (float)(target.transform.position.x + (0.5 * width * (i + 1)));
            }
        }
    }

}
