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
        Tween floating = transform.DOMoveY(transform.position.y + 0.5f, 2).SetEase(Ease.InOutQuart).SetLoops(-1,LoopType.Yoyo);
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
