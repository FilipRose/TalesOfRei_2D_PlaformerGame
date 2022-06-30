using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAutodestructor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Autodestruction", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Autodestruction()
    {
        Destroy(this.gameObject);
    }
}
