using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ThanksScript : MonoBehaviour
{

    public GameObject button;
    
    private void OnEnable()
    {
        button.GetComponent<Button>().Select();
        Time.timeScale = 0;
    }

    public void EndButton()
    {
        StartCoroutine(Button());
    }

    public IEnumerator Button()
    {
        Tween pressIn = button.transform.DOScale(0.9f, 0.2f).SetUpdate(true);
        yield return pressIn.WaitForCompletion();
        Tween pressOut = button.transform.DOScale(1.0f, 0.2f).SetUpdate(true);
        yield return pressOut.WaitForCompletion();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
