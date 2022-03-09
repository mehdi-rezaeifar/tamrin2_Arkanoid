using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 100;
    public GameObject Racket;
    public Vector3 start_position;
    public bool reset = false;

    // Start is called before the first frame update
    void Start()
    {
         start_position = transform.position;
         GetComponent<Rigidbody2D>().velocity = Vector2.up  * speed;
    }

    // Update is called once per frame
    void Update()
    {
        float ball_y=transform.position.y;
        float racket_y = Racket.transform.position.y;
        if(ball_y < racket_y - 30 && reset == false)
        {
            reset = true;
            StartCoroutine(Reset());

        }
    }
    IEnumerator Reset()
     {
            yield return new WaitForSeconds(3);
            transform.position = start_position;
            GetComponent<Rigidbody2D>().velocity = Vector2.up  * speed;
            reset = false;
    }
    
    void OnCollisionEnter2D(Collision2D mehman)
    {
        if(mehman.gameObject.name == "Racket")
        {
            float ball_x = transform.position.x;
            float racket_x = mehman.transform.position.x;
            float racket_w = mehman.collider.bounds.size.x;

           float direction_x = (ball_x - racket_x) / racket_w;
           GetComponent<Rigidbody2D>().velocity = new Vector2(direction_x , 1) * speed;
        }
        else
        {
            
        }
    }
}
