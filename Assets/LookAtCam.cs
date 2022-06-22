using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    [SerializeField]
    Transform what;
    Vector3 offset = new Vector3(0, 29, -6);

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(what); 
        transform.position = Vector3.Lerp(transform.position, what.position + offset, 0.1f);
    }
}
