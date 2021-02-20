using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    #region Editor_variables
    [SerializeField]
    [Tooltip("The effect that plays on collision.")]
    private GameObject m_Effect;
    #endregion

    #region Sound_variables
    public GameObject collisionSound;
    #endregion

    public int damage = 1;
    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    //will be called when the obstacle collides with the player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(collisionSound, transform.position, Quaternion.identity);
            Instantiate(m_Effect, transform.position, Quaternion.identity);

            //deal damage to player
            other.GetComponent<PlayerController>().health -= damage;
            Debug.Log("Player health is now " + other.GetComponent<PlayerController>().health);
            //obstacle is destroyed
            Destroy(gameObject);
        }
    }

   
}
