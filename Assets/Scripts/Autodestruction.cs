using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruction : MonoBehaviour
{
    public float timeToDestruction;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestruction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
