using UnityEngine;

public class ConsoleInput : LaserAdventureGame
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            SetGameState(GameState.Completed);
        }
    }

}
