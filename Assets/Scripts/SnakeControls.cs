using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControls : MonoBehaviour
{
    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 10;
    public int Gap = 25;

    // References
    public GameObject BodyPrefab;
    public GameObject apple;
    public GameObject firstBodySection;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<GameObject> apples = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        BodyParts.Add(firstBodySection);
        
        //Add one section to snake
        GrowSnake(); 
    }

    // Update is called once per frame
    void Update()
    {

        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Steer
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Store position history
        PositionsHistory.Insert(0, transform.position); 

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }

    public void GrowSnake()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    public void AddApple()
    {
        GameObject fruit = Instantiate(apple);
        apples.Add(fruit);

        //Generate random location for new apple
        float randomx = Random.Range(-9.5f, 9.5f);
        float randomz = Random.Range(-9.5f, 9.5f); ;

        fruit.transform.position = new Vector3(randomx, 5.3f, randomz);
    }
}