using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MenuAnimator : MonoBehaviour
{
    public bool end;
    public GameObject icon;
    public GameObject[] buttons;
    public Transform[] iconTransforms;


    void Update()
    {
        
    }

    void Animate()
    {
        if (!end)
        {
            if (EventSystem.current.currentSelectedGameObject == buttons[0])
            {
                buttons[0].transform.DOScale(1.2f, 0.5f);
            }
            else
            {
                buttons[0].transform.DOScale(1.0f, 0.5f);
            }
            
        }
    }













}
