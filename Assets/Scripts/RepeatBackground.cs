using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWith;
    void Start()
    {
        startPos = transform.position;
        repeatWith = GetComponent<BoxCollider>().size.y*7;
    }
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 40);
        if (transform.position.z < startPos.z - repeatWith)
        {
            transform.position = startPos;
        }
    }
}
