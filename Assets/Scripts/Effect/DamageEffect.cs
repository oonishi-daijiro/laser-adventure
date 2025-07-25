using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] Image DamageImg;
    void Start()
    {
        DamageImg.color = Color.clear;
    }


    void Update()
    {
        DamageImg.color = Color.Lerp(DamageImg.color, Color.clear, 10f*Time.deltaTime);
        Damaged();
    }

    void Damaged()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DamageImg.color = new Color(0.7f, 0, 0, 0.7f);
        }

    }
}
