using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private string timerId;
    [SerializeField]
    private TMP_Text text;

    private float currentTime;
    
    [SerializeField]
    private bool isRunning = false;

    [Tooltip("En Segundos")]
    public float goalTime = 120.0f;
    public bool displayAsStopwatch = false;
    public bool displayMessage = true;

    public bool alwaysReset = false;

    
    // Metodo que corre una vez el GameObject cambia su estado a Activo, e.g gameObject.SetActive(true);
    private void Awake()
    {
        if(alwaysReset){
            Reset();
        }
    }


    public void StartTimer(string tId)
    {
        if(timerId == tId)
        {
            Reset();
        }
    }

    public void StopTimer(string tId)
    {
        if(timerId == tId)
        {
            alwaysReset = false;
            isRunning = false;
        }
    }

    private void Reset()
    {
        currentTime = Time.deltaTime;
        isRunning = true;
    }

    // Metodo que corre una vez cada Frame (imagen) que se renderiza (pinta)
    private void Update()
    {
        if(isRunning)
        {
            currentTime += Time.deltaTime; // Time.time - previousTime
            if(currentTime < goalTime)
            {
                if(displayMessage)
                {
                    if(displayAsStopwatch)
                    {
                        int minutes = (int)((goalTime - currentTime)/60);
                        int seconds = (int)(goalTime - currentTime)%60;
                        Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds));
                        if(text != null)
                            text.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
                    }else
                    {
                        if(text != null)
                            text.SetText(Mathf.Floor((goalTime - currentTime) + 1).ToString());
                    }
                }
            }else
            {
                if(displayMessage)
                {
                    if(displayAsStopwatch)
                    {
                        if(text != null)
                            text.SetText("00:00");
                    }
                }
                isRunning = false;
                if(alwaysReset)
                {
                    Reset();
                }
            }
        }
    }


}
