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
        
        GetComponent<MeshRenderer>().material = fade;
        Tween Drop = transform.DOMoveY(transform.position.y - 100, 3).SetEase(Ease.InExpo);
        yield return Drop.WaitForCompletion();
        Tween Rise = transform.DOMoveY(transform.position.y + 100, 3);
        yield return Rise.WaitForCompletion();
        GetComponent<MeshRenderer>().material = main;


    }
}
