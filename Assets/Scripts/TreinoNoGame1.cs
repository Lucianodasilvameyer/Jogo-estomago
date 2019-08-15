using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreinoNoGame1 : MonoBehaviour
{
    [SerializeField]
    Plataforma plataforma_ref;

    List<Geometria> listaGeometria = new List<Geometria>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnarGeometria<Y>(int distanciaObjetoPlataforma, Vector2 inipos)
    {
        if(!typeof(Y).IsSubclassOf(typeof(Geometria)))
            return;
        inipos = plataforma_ref.transform.position;
        Vector3 position = inipos;                                                    //bounds.size.x/2 certo?
        float sizeT = plataforma_ref.GetComponent<SpriteRenderer>().bounds.size.x/2; //pq trabalhar aqui com o spriteRenderer da plataforma? 
        position.x = Random.Range(position.x - sizeT, position.x + sizeT);
        position.y = distanciaObjetoPlataforma;
        position.z = -1f;

        if(listaGeometria.Count>0)
        {
            if(typeof(Y)==typeof(Bola))
            {
                if(listaGeometria.OfType<Bola>().Any()) //pegar todos os elementos do tipo bola não é uma condição?  
                {
                    int index = listaGeometria.FindLastIndex(x => x.GetType() == typeof(Bola)); //aqui salva a posição na lista?
                    Bola b = (Bola)listaGeometria[index];
                    listaGeometria.RemoveAt(index);

                    b.transform.position = position;
                    b.gameObject.SetActive(true);
                }
            }
        }
    }
}
