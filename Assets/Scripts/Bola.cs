using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Game game_ref;


    [SerializeField]
    private float speed;

    Rigidbody2D body;
    bool isDestroy;

    



    

    // Start is called before the first frame update
    void Start()
    {
        game_ref = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();


        
                       

        if (!body || body == null)
            body = GetComponent<Rigidbody2D>();

        




    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
   
    public void Destroy()
    {
        game_ref.addPool(gameObject);
    }

}
