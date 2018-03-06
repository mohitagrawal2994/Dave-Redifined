using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    private int count;
    public Text ScoreText;
    public Text WinText;
    public GameObject CGate;
    public GameObject OGate;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        count = 0;
        ScoreText.text = "SCORE : ";
        WinText.text = "";
        CGate.SetActive(true);
        OGate.SetActive(false);
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            count += 100;
            SetCountText();

        }
        if(other.gameObject.CompareTag("Chalice"))
        {
            other.gameObject.SetActive(false);
            count += 1000;
            SetCountText();
            CGate.SetActive(false);
            OGate.SetActive(true);
        }
        if(other.gameObject.CompareTag("OpenGate"))
        {
            this.gameObject.GetComponent<DaveController>().enabled = false;
            WinText.text = "You Win";
            anim.SetBool("Stop", true);

        }
    }
    void SetCountText()
    {
        ScoreText.text = "SCORE : " + count.ToString();
    }
}
