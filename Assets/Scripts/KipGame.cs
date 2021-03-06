using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;

public class KipGame : MonoBehaviour
{

    #region FIELDS
    //total collected spirit
    public int spiritTotal;

    //position of last saved spawn point
    public Vector3 currentSpawnPoint;
    
    //respawn materials
    public Material main;
    public Material respawn;

    //feedbacks
    public MMFeedbacks spiritFeedback;

    //sounds
    public AudioSource spiritSound;
    public AudioSource activationSound;
    public AudioSource setSpawnSound;
    #endregion

    #region METHODS
    public int GetSpirit()
    {
        return spiritTotal;
    }

    //respawn coroutine runs when player falls out of map
    private IEnumerator Respawn()
    {
        //sets material to respawn and fades out
        GetComponentInChildren<SkinnedMeshRenderer>().material = respawn;
        Tween fadeout = respawn.DOFade(0, 0.5f);
        yield return fadeout.WaitForCompletion();
        
        //sets player back to spawn point
        transform.position = currentSpawnPoint;

        //fades back to 1 and sets material back to default
        Tween fadein = respawn.DOFade(1, 1);
        yield return fadein.WaitForCompletion();
        GetComponentInChildren<SkinnedMeshRenderer>().material = main;


    }
    #endregion

    #region MONOBEHAVIOURS
    private void OnTriggerEnter(Collider other)
    {
        //waystone collision event
        if (other.gameObject.CompareTag("WayStone"))
        {
            if(currentSpawnPoint != other.gameObject.GetComponentInChildren<Transform>().position)
            {
                currentSpawnPoint = other.gameObject.GetComponentInChildren<Transform>().position;
                //play spawn audio here
                setSpawnSound.Play();
                //play particle effect here
                other.GetComponentInChildren<ParticleSystem>().Play();
            }   
        }
        //falling out of map
        if (other.gameObject.CompareTag("Bounds"))
        {
            StartCoroutine(Respawn());
            //play respawn sound here
        }
        //collecting spirit
        if (other.gameObject.CompareTag("Spirit"))
        {
            spiritTotal++;
            other.gameObject.SetActive(false);
            spiritFeedback?.PlayFeedbacks();
            //play spirit sound here
            spiritSound.Play();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //waystone activation
        if (other.gameObject.CompareTag("WayStone"))
        {
            if (spiritTotal >= other.GetComponent<WayStone>().RequiredSpirit() && (Input.GetButton("Channel"))) 
            {
                //activates the activate function on the current waystone
                other.GetComponent<WayStone>().Activate();
                other.GetComponent<WayStone>().activated = true;
                //play activation sound
                activationSound.Play();
             
            }
        }
    }

    #endregion












}
