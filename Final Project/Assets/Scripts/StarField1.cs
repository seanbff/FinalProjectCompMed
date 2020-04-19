using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField1 : MonoBehaviour
{
    private ParticleSystem ps;
    public GameController gameController;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = 4.0F;
        
        if (gameController.score >= 100)
        {
            main.simulationSpeed = 60.0F;
        }
    }
}
