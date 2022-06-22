using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitApple : MonoBehaviour
{
    [SerializeField] 
    private Score UIScore;

    private void Awake()
    {
        UIScore = GameObject.Find("ScoreText").GetComponent<Score>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SnakeControls>().PlayEat();

            //delete apple play sound and grow player
            gameObject.SetActive(false);

            //print(other.gameObject);

            //Grow the snake.. Apple hit
            other.GetComponent<SnakeControls>().GrowSnake();
            other.GetComponent<SnakeControls>().AddApple();

            UIScore.GetComponent<Score>().IncrementScore();
        }
    }
}
