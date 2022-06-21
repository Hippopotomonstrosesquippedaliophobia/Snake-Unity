using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    private string nameOfRigidBody;
    
    [SerializeField]
    private float speedOfSnake;

    [SerializeField]
    private Vector3 snakeDirection = Vector3.zero;

    public Rigidbody[] snake = new Rigidbody[3];
    public Camera cam;

   // private float bodyOffset = 1f;



    //// Start is called before the first frame update
    public void Awake()
    {
        try
        {
            speedOfSnake = 1f;
            cam = Camera.main;
            snake = GameObject.Find("Snake").GetComponentsInChildren<Rigidbody>();

        }
        catch
        {
            Debug.Log("RigidBodies of snake not found!");
        }
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            Move(cam.transform.up);
        }
        if (Input.GetKey("s"))
        {
            Move(-cam.transform.up);
        }
        if (Input.GetKey("a"))
        {
            Move(-cam.transform.right);
        }
        if (Input.GetKey("d"))
        {
            Move(cam.transform.right);
        }


        // Update the body
        LookAtOthers(snake[1], snake[0].GetComponent<Transform>());
        
        //Keep snake going in direction it was facing when move was input
        snake[0].transform.Translate(snakeDirection * speedOfSnake * Time.deltaTime);

        for (int i = 2; i < snake.Length; i++)
        {
            LookAtOthers(snake[i], snake[i - 1].GetComponent<Transform>());
        }
    }

    // Update is called once per frame
    public void Move(Vector3 direction)
    {
        if (snakeDirection != -direction)
        {
            direction.y = 0;
            snakeDirection = direction;

            GameObject cube = GameObject.Find("Cube");

            cube.transform.position = snake[0].transform.position + (direction * 0.5f);


            snake[0].transform.Translate(direction * speedOfSnake * Time.deltaTime);
        }
    }

    public void LookAtOthers(Rigidbody rb, Transform who)
    {
         
    }
}
