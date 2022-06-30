using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{   
    public float heroSpeed = 4f;
    public float jumpForce = 13f;
    public Transform groundTester;
    public LayerMask layersTest;
    Animator anim;
    public Rigidbody2D rgdBody;
    bool dirToRight = true;
    public Transform startPoint;
    public  AudioClip clip;
    private bool onGround;
    private float radius = 0.1f;
    public GameManager theGM;
    private LivesManager theLM;

    private bool ctrlActive;
    private bool isDead;
    private Collider2D playerCol;
   
    public GameObject[] childObjs;
    public float shockForce;

    // Start is called before the first frame update
    void Start()
    {
        theLM = FindObjectOfType<LivesManager>();
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();

        playerCol = GetComponent<Collider2D>();

        ctrlActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        onGround = Physics2D.OverlapCircle(groundTester.position, radius, layersTest);
        float horizontalMove = Input.GetAxis("Horizontal");
        rgdBody.velocity = new Vector2(horizontalMove * heroSpeed, rgdBody.velocity.y);
       
       


        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rgdBody.velocity = new Vector2(rgdBody.velocity.x, jumpForce); 
            anim.SetTrigger("Jump");
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }

        anim.SetFloat("speed", Mathf.Abs (horizontalMove));

        if(horizontalMove < 0 && dirToRight)
        {
            Flip();

        }
        if(horizontalMove > 0 && !dirToRight)
        {
            Flip();
        }

    }
    void Flip()
    {
        dirToRight = !dirToRight;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x *= -1;
        gameObject.transform.localScale = heroScale;
        
    }
    private void FixedUpdate()
    {
        if(ctrlActive == true)
        {
            Update();
        }
    }

    public void RestartHero()
    {
        gameObject.transform.position = startPoint.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.gameObject.tag == "hit") || (other.gameObject.tag == "Enemy"))
        {
            Debug.Log("Ouch");
            theLM.TakeLife();
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        isDead = true;
        anim.SetBool("Dead", isDead);
        ctrlActive = false;
        playerCol.enabled = false;
       
        foreach (GameObject child in childObjs)
        child.SetActive(false);
        rgdBody.gravityScale = 2.5f;
        rgdBody.AddForce(transform.up * shockForce, ForceMode2D.Impulse);

        StartCoroutine("PlayerRespawn");
    }
    IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(1.5f);
        isDead = false;
        anim.SetBool("Dead", isDead);
        
        playerCol.enabled = true;
        
        foreach (GameObject child in childObjs)
        child.SetActive(true);
        rgdBody.gravityScale = 1f;

        yield return new WaitForSeconds(0.1f);
        ctrlActive = true;
        theGM.Reset();
    }
}
