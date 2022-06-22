using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            print("Died falling");
            other.GetComponent<SnakeControls>().gameOver = true;
        }
    }
}
