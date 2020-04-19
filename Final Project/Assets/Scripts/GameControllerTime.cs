using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameControllerTime : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float timeLeft = 20.0f;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text modeSelectText;
    public Text CountdownText;

    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;

    private bool gameOver;
    private bool restart;
    public int score;

    void Start()
    {
        timeLeft = 20.0f;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        gameOverText.text = "";
        modeSelectText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        musicSource.clip = musicClipOne;
        musicSource.Play();
    }

    void Update()
    {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("HardMode"); 
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("TimeMode");
        }

        timeLeft -= Time.deltaTime;
        CountdownText.text = (timeLeft).ToString("0");

        if (timeLeft <= 0)
        {
            gameOverText.text = "FINAL SCORE:" + score;
            CountdownText.text = "";
            scoreText.text = "";
            gameOver = true;
            restart = true;
        }

    }

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                musicSource.clip = musicClipTwo;
                musicSource.Play();
                restartText.text = "Press 'N' to Restart";
                modeSelectText.text = "Press 'H' for Hard Mode! Press 'T' for Time Attack!";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

void UpdateScore()
    {
        scoreText.text = "Points: " + score;

    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
