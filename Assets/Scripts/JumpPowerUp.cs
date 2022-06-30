using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float increase = 3f;
    public AudioClip sound;
    public GameObject perticlesPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject controler = collision.gameObject;
            Controler controlerScript = controler.GetComponent<Controler>();
            if (controlerScript)
            {
                controlerScript.jumpForce += increase;

                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(sound, transform.position);
                Instantiate(perticlesPrefab, transform.position, transform.rotation);
            }
        }
    }
}
