using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using SimpleInputNamespace;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed;
    public GameObject inGamePanel;
    public GameObject mainMenuPanel;
    public TextMeshProUGUI highScoreText;
    private GameObject gameManager;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Began)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.velocity = Vector2.up * jumpSpeed;
            }
            //rb.AddForce(new Vector2(0, 2) * Time.deltaTime * jumpSpeed);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Obstacle"))
        {
            if (gameManager.GetComponent<GameManager>().score > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", gameManager.GetComponent<GameManager>().score);
                highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString("0");
            }            
            SceneManager.LoadScene(0);
            /*inGamePanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            Time.timeScale = 0;*/
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Score"))
        {
            gameManager.GetComponent<GameManager>().score++;
        }
    }
}
