using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    [SerializeField]
    private Text scoreTxt;

    private void Awake()
    {
        score = 0;
        scoreTxt = transform.GetComponent<Text>();
    }

    private void Update()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void IncrementScore()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
