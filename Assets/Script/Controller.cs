using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Transform lives;
    public Slider timer;

    public void Start()
    {
        StartCoroutine(StartTimer());
    }

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
}
