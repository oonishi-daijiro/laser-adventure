using System.Collections.Generic;
using UnityEngine;

public class SetTagsToAllChildren : MonoBehaviour
{
    [SerializeField] public string tagName;
    void Start()
    {
        List<Transform> allChildren = new();
        GetAllChildrenRecuv(gameObject.transform, allChildren);
        foreach (var child in allChildren) child.tag = tagName;
    }

    void GetAllChildrenRecuv(Transform target, List<Transform> allChildrenList)
    {
        foreach (Transform child in target)
        {
            allChildrenList.Add(child);
            GetAllChildrenRecuv(child, allChildrenList);
        }
    }

}
