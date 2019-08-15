using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game : MonoBehaviour
{
    [SerializeField]
    Plataforma plataforma_ref;

    public GameObject bolaPrefab;
    public GameObject quadradoPrefab;
    public GameObject TrianguloPrefab;

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

    List<Geometria> poolGeometrias = new List<Geometria>();


    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
       // spawnarGeometria<Bola>(distanciaDeQueda, lugarDeSpawnar);

        spawnarGeometria<Quadrado>(distanciaDeQueda, lugarDeSpawnar);
        spawnarGeometria<Triangulo>(distanciaDeQueda, lugarDeSpawnar);




    }

    // Update is called once per frame
   void Update()
   {
      

      if(Time.time>=spawnarBolaInicial + spawnarBolaMax)
      {
            
            spawnarGeometria<Bola>(distanciaDeQueda, lugarDeSpawnar);
            spawnarBolaInicial = Time.time;

        }
             
   }
  

    public void spawnarGeometria<T>(int distanciaBolaPlataforma, Vector2 inicialPos)
    {
        if (!typeof(T).IsSubclassOf(typeof(Geometria)))//aqui verifica se o T é filho da geometria
            return;

        inicialPos = plataforma_ref.transform.position;
        Vector3 position = inicialPos;
        float sizeX = plataforma_ref.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        position.x = Random.Range(position.x - sizeX, position.x + sizeX);
        position.y = distanciaBolaPlataforma;
        position.z = -1;

        if (poolGeometrias.Count > 0) //quando tiver q spawnar se tem objetos na pool, utilizar eles senão criar um novo
        {                       //não entrara neste if se não houver nada na pool


            if (typeof(T) == typeof(Bola))
            {
                if (poolGeometrias.OfType<Bola>().Any()) //aqui o ofType é para pegar todos os elementos do tipo bola
                {
                    int index = poolGeometrias.FindLastIndex(x => x.GetType() == typeof(Bola)); // salva a posição
                    
                    Bola b = (Bola)poolGeometrias[index];
                    poolGeometrias.RemoveAt(index); // retira da lista

                    b.transform.position = position;//aqui acha a localização da bola
                    b.gameObject.SetActive(true);
                }


            }
            else if (typeof(T) == typeof(Quadrado))
            {
                if (poolGeometrias.OfType<Quadrado>().Any()) 
                {
                    int index = poolGeometrias.FindLastIndex(x => x.GetType() == typeof(Quadrado)); 

                    Quadrado b = (Quadrado)poolGeometrias[index];
                    poolGeometrias.RemoveAt(index); 

                    b.transform.position = position;
                    b.gameObject.SetActive(true);
                }
            }
            else if (typeof(T) == typeof(Triangulo))
            {
                if (poolGeometrias.OfType<Triangulo>().Any()) //aqui o ofType é para pegar todos os elementos do tipo bola
                {
                    int index = poolGeometrias.FindLastIndex(x => x.GetType() == typeof(Triangulo)); // salva a posição

                    Triangulo b = (Triangulo)poolGeometrias[index];
                    poolGeometrias.RemoveAt(index); // retira da lista

                    b.transform.position = position;//aqui o position é onde o objeto sera spawnada
                    b.gameObject.SetActive(true);
                }
            }



        }
        else
        {
            if(typeof(T) == typeof(Bola))
            {
                Instantiate(bolaPrefab, position, Quaternion.identity);
            }
            else if (typeof(T) == typeof(Quadrado))
            {
                Instantiate(quadradoPrefab, position, Quaternion.identity);
            }
            else if (typeof(T) == typeof(Triangulo))
            {
                Instantiate(TrianguloPrefab, position, Quaternion.identity);
            }


        }


    }

    public void addPool(Geometria bola)//quando tiver q ser destruido se a pool ainda tem espaço,adicionar na pool senão,destruir
   {
        if (poolGeometrias.Count < poolMax)
        {
            poolGeometrias.Add(bola);
        }
        else
        {
            bola.playSfx(bola.destructionSound);
            Destroy(bola);

         
        }
   }   




} 
