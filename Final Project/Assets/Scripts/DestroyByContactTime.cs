using UnityEngine;
using System.Collections;

public class DestroyByContactTime : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    private GameControllerTime gameControllerTime;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameControllerTime = gameControllerObject.GetComponent<GameControllerTime>();
        }
        if (gameControllerTime == null)
        {
            Debug.Log("WOW");
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) 
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameControllerTime.GameOver ();
        }

        gameControllerTime.AddScore (scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}