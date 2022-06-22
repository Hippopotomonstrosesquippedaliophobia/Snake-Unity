using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithSelf : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("hit self");
            if (other.name == "snakehead")
            {
                other.GetComponent<SnakeControls>().gameOver = true;
            }
        }
    }
}
