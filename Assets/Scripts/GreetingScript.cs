using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GreetingScript : MonoBehaviour
{
    public GameObject window;
    public GameObject backButton;
    // Start is called before the first frame update
    void Start()
    {
        window.transform.DOMoveY(transform.position.y + 1000, 1).SetUpdate(true).SetEase(Ease.OutBack);
        backButton.GetComponent<Button>().Select();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BackButton()
    {
        StartCoroutine(Accept());
    }

 

    public IEnumerator Accept()
    {
        Tween pressIn = backButton.transform.DOScale(0.9f, 0.2f).SetUpdate(true);
        yield return pressIn.WaitForCompletion();
        Tween pressOut = backButton.transform.DOScale(1.0f, 0.2f).SetUpdate(true);
        yield return pressOut.WaitForCompletion();
        Tween down = window.transform.DOMoveY(transform.position.y - 1000, 1).SetUpdate(true).SetEase(Ease.InBack);
        yield return down.WaitForCompletion();
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
