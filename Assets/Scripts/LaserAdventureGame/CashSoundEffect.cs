using Unity.VisualScripting;
using UnityEngine;

public class CashSoundEffect : MonoBehaviour
{
    AudioSource cashSE;
    private bool isAlreadyTouched = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cashSE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (!isAlreadyTouched)
        {
            cashSE.PlayOneShot(cashSE.clip);
            isAlreadyTouched = true;
            GetComponent<Renderer>().material.color = new Color32(0,0,0,0);
        }
    }
}
