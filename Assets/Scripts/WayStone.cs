using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WayStone : MonoBehaviour
{
    public GameObject activeArea;
    [SerializeField] TMP_Text requiredSpiritText;
    public int requiredSpirit;
    public bool activated = false;

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
    public int RequiredSpirit()
    {
        return requiredSpirit;
    }
    public void Activate()
    {
        activeArea.SetActive(true);
    }

}
