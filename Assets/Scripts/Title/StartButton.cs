using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] string sceneName;
    public void OnClickButton()
    {
        SceneManager.LoadScene(sceneName);
    }

}
