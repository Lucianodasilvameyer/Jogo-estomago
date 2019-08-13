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

    Bola bola_ref;
    [SerializeField]
    int poolMax;

    Queue<GameObject> poolBola = new Queue<GameObject>();


    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        spawnarBola(distanciaDeQueda, lugarDeSpawnar);
        



        
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
        if (poolBola.Count > 0) //quando tiver q spawnar se tem objetos na pool, utilizar eles senão criar um novo
        {                       //não entrara neste if se não houver nada na pool
            GameObject bola = poolBola.Dequeue();
            bola.transform.position = position;//aqui acha a localização da bola
            bola.SetActive(true);
        }
        else
        {

            GameObject ru = Instantiate(bolaPrefab, position, Quaternion.identity);
        }
        

   }
   public void addPool(GameObject bola)//quando tiver q ser destruido se a pool ainda tem espaço,adicionar na pool senão,destruir
   {
        if (poolBola.Count < poolMax)
        {
            poolBola.Enqueue(bola);
        }
        else
        {
            Destroy(bola);
        }
   }   




} 
