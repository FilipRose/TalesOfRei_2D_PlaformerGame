using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    public int damageToDeal;
    private Rigidbody2D rb2D;
    public float bouceForce;
    public AudioClip sound;
    public GameObject preFab;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = transform.parent.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "HitBox")
        {
            other.gameObject.GetComponent<Enemyhp>().TakeDamage(damageToDeal);
            rb2D.AddForce(transform.up * bouceForce, ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Instantiate(preFab, transform.position, transform.rotation);
        }
    }

}
