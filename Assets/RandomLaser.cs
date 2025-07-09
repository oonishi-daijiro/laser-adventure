using UnityEngine;

public class RandomLaser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject original;
    void Start()
    {

        for (int i = 0; i < 20; i++)
        {
            var randomPos = new Vector3(Random.Range(-10, 10), Random.Range(0, 5), Random.Range(-10, 10));
            var randomRot = Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
            Instantiate(original, randomPos, randomRot, gameObject.transform); // do not pass own game object at first argument!!!!
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
