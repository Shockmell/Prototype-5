using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGame = true;
    public Button restart;
    public GameObject titleScreen;

    private float spawnRate = 1.0f;
    private int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {
        while(isGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreAdded)
    {
        score += scoreAdded;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGame = false;
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGame = true;
        titleScreen.gameObject.SetActive(false);
        spawnRate = difficulty / spawnRate;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
    }
}