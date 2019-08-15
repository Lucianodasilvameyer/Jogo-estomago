using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometria : MonoBehaviour
{
    Game game_ref;


    [SerializeField]
    protected float speed;

    protected Rigidbody2D body;
    protected bool isDestroy;


    public AudioSource audioSource;
    public AudioClip destructionSound;
    public AudioClip bounceSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSfx(AudioClip sfx)
    {
        audioSource.clip = sfx;
        audioSource.Play();
    }

    public void Destroy()
    {
        playSfx(destructionSound);
        game_ref.addPool(this);
    }


}
