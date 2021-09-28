using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WayStone : MonoBehaviour
{
    #region FIELDS
    //area to spawn upon activation
    public GameObject activeArea;
    //floating text
    [SerializeField] TMP_Text requiredSpiritText;
    //spirit required to unlock next level
    public int requiredSpirit;
    //has the waystone been activated
    public bool activated = false;
    #endregion

    //sets floating text to required spirit and turns text off on activation
    private void Update()
    {
        if (activated == false)
        {
            requiredSpiritText.text = RequiredSpirit().ToString();
        }
        else if(activated == true)
        {
            requiredSpiritText.text = "";
        }
    }
    //returns required spirit
    public int RequiredSpirit()
    {
        return requiredSpirit;
    }
    //unlocks the active area
    public void Activate()
    {
        activeArea.SetActive(true);
    }

}
