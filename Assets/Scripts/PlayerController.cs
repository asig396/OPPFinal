using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager; // INHERITANCE
    private float horizontalInput;
    public float speed = 10.0f;
    private float xRange = 45; // ENCAPSULATION
    public TextMeshProUGUI score;
    private Rigidbody playerRb; // ENCAPSULATION
    //private Quaternion startRotation;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (gameManager.isGameActive == true) // INHERITANCE
        {
            BounderiesAndMove();// ABSTRACTION
            Shoot();// ABSTRACTION
            playerAnimation();// ABSTRACTION
        }
    }
    void playerAnimation()
    {
        if (transform.position.z != 0)
        { 
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed * Time.deltaTime);
        }
        //Quaternion targetRotation = Quaternion.Euler(Vector3.zero);
        //transform.rotation = Quaternion.Slerp(startRotation, targetRotation, Time.deltaTime * 10);
    }
    void BounderiesAndMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.right * horizontalInput * speed);

        //transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position + Vector3.forward * 7; // position it at player
            }
        }
    }
}
