using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Movement : MonoBehaviour
{

    private float speed = 15f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
