using UnityEngine;

public class TrackRangeContoroller : LaserAdventureGame
{
    [SerializeField] public float min;
    [SerializeField] public float max;

    void Update()
    {
        if (!(min < Mathf.Abs(gameObject.transform.position.z) && Mathf.Abs(gameObject.transform.position.z) < max))
        {
            gameObject.transform.position = new Vector3(0, -10, 0);
        }
    }
}
