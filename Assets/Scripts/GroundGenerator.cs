using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    //public float maxHeight;
    //public float minHeight;
    //public float maxStep;
    //private float previousGroundY = 10f;
    void Start()
    {
        InvokeRepeating("GenerateNewGround", 0, 2);
    }

   
    void GenerateNewGround()
    {   // float newY;
        //do{
        // float newY = Random.Range(minHeight, maxHeight);
        // } while (newY > maxStep + previousGroundY);
        //
        // Vector3 tragetPrefabPosition = new Vector3(this.transform.position.x, newY, this.transform.position.z ); randomowe po³o¿enie generowanego pod³o¿a, pod³akadaæ to za this.transform.position
        // previousGroundY = tragetPrefabPosition.y;
        //int IndexElement = Random.Range(0, groundPrefabs.Length);
        Instantiate(groundPrefabs[Random.Range(0, groundPrefabs.Length)], this.transform.position, Quaternion.identity);
        //Debug.Log(IndexElement);
    }
}
