using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadePlatformScript : MonoBehaviour
{

    Material[] materials;
    [SerializeField] private Material main;
    [SerializeField] private Material sandstone;
    [SerializeField] private Material magic;
    [SerializeField] private Material fade;

    // Start is called before the first frame update
    void Start()
    {
        main = GetComponent<MeshRenderer>().material;
        StartCoroutine(Fading());

    }

    // Update is called once per frame
    void Update()
    {
        if(this == null)
        {
            
        }
    }

    public IEnumerator Fading()
    {
        while (this != null)
        {
            yield return new WaitForSeconds(3);
            GetComponent<MeshRenderer>().material = fade;
            GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(3);
            GetComponent<MeshRenderer>().material = sandstone;
            GetComponent<Collider>().enabled = true;
        }


    }
}
