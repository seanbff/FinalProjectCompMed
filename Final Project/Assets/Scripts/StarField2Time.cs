using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField2Time : MonoBehaviour
{
    private ParticleSystem ps;
    public GameControllerTime gameControllerTime;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = 4.0F;

        if (gameControllerTime.timeLeft <= 0)
        {
            main.simulationSpeed = 60.0F;
        }
    }

}
