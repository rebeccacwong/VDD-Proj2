using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    #region Score_variables
    public int score;
    public Text scoreDisplay;
    public PlayerController player;
    #endregion

    private void Update()
    {
        if (player.health > 0)
        {
            scoreDisplay.text = "Score: " + score.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            //increase score by 1
            score++;
            Debug.Log(score);
        }
    }
}
