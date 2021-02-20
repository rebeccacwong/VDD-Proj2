using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBG : MonoBehaviour
{

    #region Editor Variables
    [SerializeField]
    [Tooltip("The speed that the background should move")]
    public float speed;

    [SerializeField]
    [Tooltip("The x value that the BG should end at")]
    public float endX;

    [SerializeField]
    [Tooltip("The x value that the BG should start at")]
    public float startX;
    #endregion


    #region Main Updates
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < endX)
        {
            Vector3 pos = new Vector3(startX, transform.position.y, transform.position.z);
            transform.position = pos;
        }

        Vector3 new_pos = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        transform.position = new_pos;
    }
    #endregion
}
