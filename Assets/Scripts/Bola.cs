using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : Geometria
{
   



    // Start is called before the first frame update
    void Start()
    {
     //   game_ref = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();

        if (!audioSource || audioSource == null)
            audioSource = GetComponent<AudioSource>();





        if (!body || body == null)
            body = GetComponent<Rigidbody2D>();

        




    }

   

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playSfx(bounceSoundBola);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
    }


}
