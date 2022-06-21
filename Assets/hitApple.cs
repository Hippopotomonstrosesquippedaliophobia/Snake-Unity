using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitApple : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //delete apple play sound and grow player
            gameObject.SetActive(false);

            //print(other.gameObject);

            //Grow the snake.. Apple hit
            other.GetComponent<SnakeControls>().GrowSnake();
            other.GetComponent<SnakeControls>().AddApple();
        }
    }
}
