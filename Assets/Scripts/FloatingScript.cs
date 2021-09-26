using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FloatingScript : MonoBehaviour
{

    Tween floater;
    public float magnitude = 0.1f;
    public float time = 2f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    IEnumerator Floating()
    {
        yield return new WaitForSeconds(5);
        floater = transform.DOLocalMoveY(transform.position.y + magnitude, time).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        if(this == null)
        {
            floater.Kill();
        }
    }
}
