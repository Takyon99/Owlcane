using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayStone : MonoBehaviour
{
    public GameObject activeArea;

    public int requiredSpirit;
    public bool activated = false;



    public int RequiredSpirit()
    {
        return requiredSpirit;
    }
    public void Activate()
    {
        activeArea.SetActive(true);
    }

}
