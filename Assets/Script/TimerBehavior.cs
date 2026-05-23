using System;
using UnityEngine;
using TMPro;
public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    [SerializeField] public float remainingTime;

    public GameManager gameManagerReference;

    public Bar Bar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float maxTime;
    void Start()
    {
        remainingTime = maxTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0;
            if (Bar.progress >= Bar.totaltime)
            {
                gameManagerReference.TriggerWinState();
            }
            else
            {
                gameManagerReference.TriggerLooseState();
            }
        }
        int seconds = Mathf.FloorToInt(remainingTime % maxTime);
        timerText.text = string.Format("{000}", seconds);
    }
}
