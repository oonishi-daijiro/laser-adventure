using UnityEngine;

public class EnableOnEditor : MonoBehaviour
{
    void Start()
    {
#if UNITY_EDITOR
#else
        gameObject.SetActive(false);
#endif
    }
}
