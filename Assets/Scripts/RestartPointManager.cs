using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPointManager : MonoBehaviour
{
    public Controler controler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void UpdateStartPoint(Transform newTransform)
    {
        controler.startPoint = newTransform;
    }
}
