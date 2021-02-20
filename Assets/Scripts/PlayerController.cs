using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The effect that trails the player.")]
    private GameObject m_Effect;
    #endregion

    #region Position_variables
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    #endregion

    #region Health_variables
    public int health = 3;
    public Text healthDisplay;
    #endregion

    #region Restart_variables
    public GameObject gameOver;
    #endregion

    #region Sound_variables
    public GameObject bubbleSound;
    #endregion

    // Update is called once per frame
    private void Update()
    {
        healthDisplay.text = "Health: " + health.ToString();

        if (health <= 0)
        {
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);

        //
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(bubbleSound, transform.position, Quaternion.identity);
            Instantiate(m_Effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(bubbleSound, transform.position, Quaternion.identity);
            Instantiate(m_Effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }

    }
}
