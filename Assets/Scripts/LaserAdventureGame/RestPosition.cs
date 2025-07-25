using UnityEngine;

public class RestPosition : LaserAdventureGame
{
    void Update()
    {
        if (GetGameState() == GameState.Yet)
        {
            Debug.Log("reset");
            gameObject.transform.position = initialHMDPosition;
            SetGameState(GameState.Playing);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("reset by admin");
            gameObject.transform.position = initialHMDPosition;
        }
    }
}
