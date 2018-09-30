using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Text CountText;
    public Text WinText;
    private Rigidbody2D rb2D;
    private int count;
    

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        WinText.text = " ";
    }
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.AddForce(movement*Speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            WinText.text = "YOU WIN!";
        }
    }
}
