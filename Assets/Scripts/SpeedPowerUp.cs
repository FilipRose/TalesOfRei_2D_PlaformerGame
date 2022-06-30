using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float increase = 4f;
    public AudioClip take;
    public GameObject perticlesPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject controler = collision.gameObject;
            Controler controlerScript = controler.GetComponent<Controler>();
            if (controlerScript)
            {
                controlerScript.heroSpeed += increase;
                AudioSource.PlayClipAtPoint(take, transform.position);
                Destroy(this.gameObject);
                Instantiate(perticlesPrefab, transform.position, transform.rotation);
            }
        }
    }

    
}
