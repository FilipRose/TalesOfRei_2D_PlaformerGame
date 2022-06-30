using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Controler thePlayer;
    public Vector2 playerStart;
    public GameObject victoryPanel;
    public GameObject gameOverPanel;
    public string mainMenu;
  
  
    // Start is called before the first frame update
    void Start()
    {
        playerStart = thePlayer.transform.position;
    }
    public void Victory()
    {
        victoryPanel.SetActive(true);
        thePlayer.gameObject.SetActive(false);
    }
    public void GameOver()
    {
       gameOverPanel.SetActive(true);
        thePlayer.gameObject.SetActive(false);

        StartCoroutine("GameReset");

    }
    IEnumerator GameReset()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(mainMenu);
    }
    public void Reset()
    {
        victoryPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = playerStart;

    }

   
}
