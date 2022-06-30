using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPoint : MonoBehaviour
{
    RestartPointManager restartPointManager;
    SpriteRenderer sprRenderer;
    [SerializeField]
    GameManager gameManager;
    bool visited;

    // Start is called before the first frame update
    void Start()
    {
        visited = false;
        restartPointManager = GameObject.Find("Manager").GetComponent<RestartPointManager>();
        if(restartPointManager == null)
        {
            Debug.LogError("RestartPointManager nie zosta³ zanaleziony.");
        }
        sprRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && visited == false)
        {
            visited = true;
            restartPointManager.UpdateStartPoint(this.gameObject.transform);
            sprRenderer.color = new Color(0.7f, 1f, 0f);
            gameManager.playerStart = this.transform.position;
        }
    }

}
