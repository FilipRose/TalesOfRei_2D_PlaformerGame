using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhp : MonoBehaviour
{
    public int enemyHP;
    private int currentHP;
    public AudioClip clip;
    
    

    private Collider2D parentCol;
    private Collider2D hurtboxCol;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = enemyHP;
        parentCol = transform.parent.GetComponent<Collider2D>();
        hurtboxCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP <= 0)
        {
           
          
           
            parentCol.enabled = false;
            hurtboxCol.enabled = false;
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(transform.parent.gameObject);

        }
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
 
}
