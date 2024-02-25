using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody targetRB;
    private GameManager gameManager; // INHERITANCE
    private float maxTorque = 10;
    private float xRange = 48;
    private float zSpawnPos = 130;
    private Vector3 force = Vector3.back * 1; // ENCAPSULATION
    private string enemyName;


    public ParticleSystem explosionParticle;
    public int pointValue;
    private float enemySpeed; // ENCAPSULATION
    private float enemySpawn; // ENCAPSULATION

    // Start is called before the first frame update
    void Start()
    {
        enemyName = gameObject.name;
        targetRB = GetComponent<Rigidbody>();
        //Find the object called Game Manager and get the script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        enemySpawn = gameManager.spawnRate;
        if (enemySpawn < 1)
        {
            enemySpeed = 3;
        }
        else
        {
            enemySpeed = 2;
        }

        targetRB.AddForce(SelectedForce() * enemySpeed, ForceMode.Impulse);
        if (gameObject.CompareTag("Asteroid"))
        {
            targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        }
        transform.position = RandomSpawnPos();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (gameManager.isGameActive)
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
            //Another way to call particles, in this case explosion particles
            Instantiate(explosionParticle, other.transform.position, explosionParticle.transform.rotation);
            //Update the score of the script Game Manager with our own variable
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    other.gameObject.SetActive(false);
        //}
        if (gameObject.CompareTag("Enemy")|| gameObject.CompareTag("Asteroid"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 SelectedForce()
    {
        switch (enemyName)
        {
            case "Asteroid Lava Red(Clone)":
                force = Vector3.back * 10;
                return force;
            case "Flying Insect(Clone)":
                force = Vector3.back * 15;
                return force;
            case "Mine Sample 1(Clone)":
                force = Vector3.back * 5;
                return force;
            case "Missile(Clone)":
                force = Vector3.back * 5;
                return force;
            case "StarSparrow7(Clone)":
                force = Vector3.back * 20;
                return force;
        }
        return force;
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), 0, zSpawnPos);
    }
}
