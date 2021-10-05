using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FloatingScript : MonoBehaviour
{

    Tween floater;
    public float magnitude = 0.1f;
    public float time = 2f;


    IEnumerator Floating()
    {
        //waits for 5 seconds before begining looping float animation
        yield return new WaitForSeconds(5);
        floater = transform.DOLocalMoveY(transform.position.y + magnitude, time).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        //makes sure tween is killed when object is disabled
        if(this == null)
        {
            floater.Kill();
        }
    }
}
