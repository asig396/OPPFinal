using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    void Update()
    {
        if (transform.position.z > 120)
        {
            // Instead of destroying the projectile when it leaves the screen
            // Just deactivate it
            gameObject.SetActive(false);
        }
    }
}
