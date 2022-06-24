using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollBg : MonoBehaviour
{
    private float speed;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameManager.gameSpeed;
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if ( transform.position.x < -23.7234)
        {
            transform.position = startPosition;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log(transform.position.x);
        }
    }
}
