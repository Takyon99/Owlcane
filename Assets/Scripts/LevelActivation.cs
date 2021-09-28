using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelActivation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(LevelSpawn());
    }

    IEnumerator LevelSpawn()
    {
        Tween start = transform.DOMoveY(transform.position.y - 100f, 0);
        yield return start.WaitForCompletion();
        yield return new WaitForSeconds(2);
        Tween rise = transform.DOMoveY(transform.position.y + 100f, 5);
    }

}
