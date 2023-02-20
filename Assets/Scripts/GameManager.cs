using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public float spawnRange;
    public GameObject[] enemies;
    public GameObject[] menus;
    public int enemiesKilled = 0;
    public int lifes = 3;
    public TextMeshProUGUI enemiesKilledText;
    public TextMeshProUGUI livesRemain;
    public bool gameIsOver = false;
    public int difficulty = 1;
    public float speedMultiplier = 1;


    void Awake()
    {
        
    }

    public void StartGame()
    {
        difficulty = 1;
        speedMultiplier = 1;
        enemiesKilled = 0;
        lifes = 3;
        menus[2].SetActive(false);
        gameIsOver = false;
        InvokeRepeating("SpawnEnemies", 2 , 1.5f);
        menus[0].SetActive(false);
        menus[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        enemiesKilledText.text = "Score: " + enemiesKilled;
        livesRemain.text = "Lifes: " + lifes;
        DifficultyUp();
        if (lifes < 1)
        {
            GameOver();
        }
    }

    void SpawnEnemies()
    {   int enemiesIndex = Random.Range(0,difficulty);
        spawnRange = Random.Range(-9,9);
        Instantiate(enemies[enemiesIndex] , new Vector3 (spawnRange,10,0) , enemies[enemiesIndex].transform.rotation);
    }

    public void GameOver()
    {
        menus[2].SetActive(true);
        menus[1].SetActive(false);
        gameIsOver = true;
        CancelInvoke();
    }

    void DifficultyUp()
    {
        if (enemiesKilled > 10)
        {
            difficulty = 2;
        }

        if (enemiesKilled > 20) 
        {
            speedMultiplier = 1.5f;
        }
    }
}
