using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public TextMeshProUGUI Score; // Changed to TextMeshProUGUI for UI compatibility
    private int scoreText;       // Initialized with 0 by default
    public GameObject star;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision is found");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision Detected");
            IncreasePower();
            IncreaseCount();
            DestroyStar();
        }
    }

    void IncreasePower()
    {
        Debug.Log("Power is increased");
        // Add your power-up logic here
    }

    void IncreaseCount()
    {
        scoreText += 1;
        Score.text = "Score: " + scoreText.ToString();
        Debug.Log("The score is: " + scoreText); // Log the updated score
    }

    void DestroyStar()
    {
        if (star != null)
        {
            Destroy(star);
            Debug.Log("Star is destroyed");
        }
        else
        {
            Debug.LogWarning("Star reference is not assigned in the Inspector!");
        }
    }
}
