using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private int bunnyCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        bunnyCount = 9;
        SetCountText();
        winText.text = "";
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
            bunnyCount += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString() + "Bunnies Left:"; // + bunnyCount.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}