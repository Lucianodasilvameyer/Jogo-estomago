using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Plataforma plataforma_ref;

    public GameObject bolaPrefab;

    [SerializeField]
    private float spawnarBolaInicial;

    [SerializeField]
    private float spawnarBolaMax;

    [SerializeField]
    private int distanciaDeQueda;

    Vector2 lugarDeSpawnar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
   {
      if(Time.time>=spawnarBolaInicial + spawnarBolaMax)
      {
            
            spawnarBola(distanciaDeQueda, lugarDeSpawnar);
            spawnarBolaInicial = Time.time;

        }
             
   }
   public void spawnarBola(int distanciaBolaPlataforma, Vector2 inicialPos)
   {
        inicialPos = plataforma_ref.transform.position;
        Vector3 position = inicialPos;
        float sizeX = plataforma_ref.GetComponent<SpriteRenderer>().bounds.size.x/2;
        position.x = Random.Range(position.x - sizeX, position.x + sizeX);
        position.y = distanciaBolaPlataforma;
        position.z = -1;
        GameObject ru = Instantiate(bolaPrefab, position, Quaternion.identity);

   }
   



} 
