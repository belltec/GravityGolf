using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rigidbody;
    private int count;
    private int pickupcount;

    public float speed;
    public Text countText;
    public Text winText;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        count = 0;
        pickupcount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
        SetCountText();
        winText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce(force * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            SetWinText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count :  " + count.ToString();
    }

    void SetWinText()
    {
        if (count >= pickupcount)
        {
            winText.text = "YOU WIN!";
        }
    }
}
