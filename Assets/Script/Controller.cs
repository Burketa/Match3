using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    #region Public Variables

    public Transform lives;
    public Slider timer;

    #endregion

    #region Private Methods

    public void Start()
    {
        StartCoroutine(StartTimer());
    }
    #endregion

    #region Public Methods

    public void TakeLife()
    {
        int i = 0;
        foreach (Transform life in lives)
        {
            if (life.gameObject.activeSelf)
            {
                life.gameObject.SetActive(false);
                break;
            }
            else
                i++;
        }
        if (i >= 2)
            SceneManager.LoadScene(0);
    }

    public void ResetTimer()
    {
        timer.value = timer.maxValue;
    }

    public IEnumerator StartTimer()
    {
        while (true)
        {
            timer.value -= Time.deltaTime;
            if (timer.value <= 0)
            {
                TakeLife();
                ResetTimer();
            }
            yield return null;
        }
    }

    public void AddTime(float qtd)
    {
        timer.value += qtd;
        Mathf.Clamp(timer.value, 0, timer.maxValue);
    }

    #endregion
}
