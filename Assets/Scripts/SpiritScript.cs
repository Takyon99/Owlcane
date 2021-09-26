using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpiritScript : MonoBehaviour
{
    private Tween floating;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Floating());
    }

    IEnumerator Floating()
    {
        yield return new WaitForSeconds(10);
        Tween floating = transform.DOMoveY(transform.position.y + 0.3f, 1).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        if(this == null)
        {
            floating.Kill();
        }
    }
}
