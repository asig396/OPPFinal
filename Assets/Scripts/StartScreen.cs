using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class StartScreen : MonoBehaviour
{
    private Button button;
    private GameManager gameManager; // INHERITANCE
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked on " + difficulty);
        //Assignt to Game Manager Script
        gameManager.StartGame(difficulty);
    }
}
