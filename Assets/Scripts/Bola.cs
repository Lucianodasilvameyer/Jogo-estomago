using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        if (!body || body == null)
            body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moverBola();
    }
    public void moverBola()
    {
        Vector2 input = new Vector2(0, 1);
        Vector2 direction = input.normalized;
        Vector2 velocity = speed * direction;
        velocity.x = body.velocity.x;
        body.velocity = velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("colisor"))
        {

        }  
    }

}
