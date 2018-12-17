using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text bunnyCountText;
    public Text timeText;
    public Text winText;
    public float gameTimer = 60f;
    //private float resetTimer = 3f;

    private Rigidbody rb;
    private int count;
    private int bunnyCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        bunnyCount = 9;
        SetCountText();
        SetBunnyCountText();
        winText.text = "";
    }

    void Update()
    {
        if (bunnyCount == 0 && count == 12)
        {
            Time.timeScale = 0f;
            winText.text = "You win - full score!";
        }
        gameTimer -= Time.deltaTime;
        if (gameTimer > 0f)
        {
            winText.text = "Roll over all the bunnies! \nCollect as many yellow collectibles as possible!";
            timeText.text = "Time: " + Mathf.Floor(gameTimer);
        }
        else
        {
            Time.timeScale = 0f;
            if (bunnyCount == 0)
            {
                if (count == 12)
                {
                    winText.text = "You win - full score!";
                }
                else
                {
                    winText.text = "You win with " + count.ToString() + "points!";
                }
            }
            else
            {
                winText.text = "You Lose :(";
            }
            //infoText.text = "Game over! Your score: " + Mathf.Floor(player.score);

            //resetTimer -= Time.deltaTime; 
            //if (resetTimer <= 0f)
            //{
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            //}
            if (Input.GetKey("space"))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectibles"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Bunny"))
        {
            Debug.Log("BUNNY COLLISION");
            other.gameObject.SetActive(false);
            bunnyCount -= 1;
            SetBunnyCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }

    void SetBunnyCountText()
    {
        bunnyCountText.text = "Bunnies Remaining: " + bunnyCount.ToString();
    }
}