using UnityEngine;

public class FireGenerator : LaserAdventureGame
{
    [SerializeField] GameObject fire;
    [SerializeField] int count;
    [SerializeField] float margin;

    void Start()
    {
        var posX = fire.transform.position.x;
        var size = fire.GetComponent<Renderer>().bounds.size;

        for (int i = 0; i < count; i++)
        {
            Instantiate(fire, new Vector3(posX, fire.transform.position.y, fire.transform.position.z), Quaternion.identity, gameObject.transform);
            posX += margin;
        }
    }

    void Update()
    {
        if (GetGameState() == GameState.PlayingPostureLaser)
        {
            transform.position = new Vector3(0, 100, 0);
        }
    }
}
