using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;

public class LevelActivation : MonoBehaviour
{
    public MMFeedbacks LevelFeedback;


    void Start()
    {
        LevelFeedback.Initialization();
        StartCoroutine(LevelSpawn());
        
    }

    IEnumerator LevelSpawn()
    {
        
        LevelFeedback?.PlayFeedbacks();
        Tween start = transform.DOMoveY(transform.position.y - 100f, 0);
        yield return start.WaitForCompletion();
        yield return new WaitForSeconds(2);
        Tween rise = transform.DOMoveY(transform.position.y + 100f, 5);
    }

}
