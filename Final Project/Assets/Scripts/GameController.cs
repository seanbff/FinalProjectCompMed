using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text modeSelectText;

    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;

    private bool gameOver;
    private bool restart;
    public int score;

    void Start()
    {
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
        if (score >= 100)
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            gameOverText.text = "You win! Game created by Sean Bergeron.";
            gameOver = true;
            restart = true;
        }
    }

    public void GameOver()
    {
        musicSource.clip = musicClipThree;
        musicSource.Play();
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
