using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    
    [SerializeField] private KipGame kipGame;
    [SerializeField] private TMP_Text total;

    // Update is called once per frame
    void Update()
    {
        //sets UI element equal to current spirit total
        total.text = kipGame.GetSpirit().ToString();
    }
}
