using System;
using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    public Hide Player;
    public SpriteRenderer enemyRend;
    
    [Header("Colors")]
    public Color awareColor;
    public Color windupColor;
    public Color unawareColor;
    
    private bool isObserving = false;
    public float maxWindupTimer = 1f;
    private float windupTimer;
    public GameManager gameManagerReference;
    [SerializeField] private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("ObservePlayer",4.0f, 1.0f);
    }

    private void Update()
    {
        if (isObserving)
        {
            if (Player.isHidden) windupTimer = Mathf.Max(windupTimer - Time.deltaTime, 0);
            else windupTimer += Time.deltaTime;
            
            float t = windupTimer / maxWindupTimer;
            
            enemyRend.color = Color.Lerp(windupColor, awareColor, t);
            
            if (windupTimer >= maxWindupTimer)
            {
                gameManagerReference.TriggerLooseState();
            }
        }

        if (isObserving)
        {
            animator.SetBool("isAware", true);
        }
        else
        {
            animator.SetBool("isAware", false);
        }
    }

    // Update is called once per frame
    void ObservePlayer()
    {
        if (Random.Range(0, 7) == 0)
        {
            isObserving = !isObserving;
            if (isObserving)
            {
                enemyRend.color = windupColor;
            }
            else
            {
                enemyRend.color = unawareColor;
                windupTimer = 0f;
            }
            Debug.Log("color change");
        }
    }
}