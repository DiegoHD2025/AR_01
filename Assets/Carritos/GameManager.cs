using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public float currentTime = 30f;
    public float maxTime = 30f;
    public float minTime = 1f;
    public bool gameEnded = false;
    public GameObject giftObject;

    private bool giftCollectedThisCycle = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (gameEnded) return;

        currentTime -= Time.deltaTime;
        UIManager.Instance.UpdateTimer(currentTime);

        if (currentTime <= 0f)
        {
            if (!giftCollectedThisCycle)
            {
                EndGame();
            }
            else
            {
                // Previene que se ejecute si ya se reinició el tiempo
                currentTime = maxTime;
                giftCollectedThisCycle = false;
            }
        }
    }

    public void CollectGift()
    {
        if (gameEnded) return;

        score++;
        UIManager.Instance.UpdateScore(score);

        // Reduce el tiempo máximo para la siguiente ronda
        maxTime = Mathf.Max(minTime, maxTime - 1f);

        currentTime = maxTime;
        giftCollectedThisCycle = true;
    }

    public void EndGame()
    {
        gameEnded = true;
        UIManager.Instance.ShowGameOver();
        giftObject.SetActive(false);
    }
}

