using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAsteroid : MonoBehaviour
{
    public float speedAsteroid;


    private Rigidbody rbA;

    void Start()
    {
        rbA = GetComponent<Rigidbody>();
        rbA.velocity = transform.forward * speedAsteroid;
    }

}
