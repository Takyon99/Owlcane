using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;

public class LevelActivation : MonoBehaviour
{
    //the camera shake feedback
    public MMFeedbacks LevelFeedback;

    void Start()
    {
        //initializes camera shake feedback
        LevelFeedback.Initialization();
        //starts level activation coroutine
        StartCoroutine(LevelSpawn());
        
    }

    IEnumerator LevelSpawn()
    {
        //starts camera shake
        LevelFeedback?.PlayFeedbacks();
        //sets object transform far below level
        Tween start = transform.DOMoveY(transform.position.y - 100f, 0);
        yield return start.WaitForCompletion();
        yield return new WaitForSeconds(2);
        //tweens the island back to its starting point
        Tween rise = transform.DOMoveY(transform.position.y + 100f, 5);
    }

}
