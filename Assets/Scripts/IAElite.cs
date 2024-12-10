using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAElite : MonoBehaviour
{

    //Uma aplica��o que consegue ir para todos os destinos de uma lista, ela trabalha no sentido progress�o, seguindo a ordem.
    //sempre que encontra um destino, segue para o pr�ximo.
    //Quando encontra uma Flag(Tesouro) para.

    public GameObject Destino;
    public NavMeshAgent Agente;
    public List<GameObject> Destinos;
    public GameObject Tesouro;
    public bool objetivo = false;
    public int numero;

    private void Start()
    {
        int n = Destinos.Count;
        numero = Random.Range(0, n);
        Destino = Destinos[numero];


    }
    void Update()
    {
        if (objetivo == false)
        {
            Vector3 meuDestino = Destino.transform.position;
            Agente.SetDestination(meuDestino);
            //Tesouro
            if (Vector3.Distance(transform.position, Tesouro.transform.position) < 10)
            { 
                objetivo = true;
                Agente.speed = 0;
            }else if (Vector3.Distance(transform.position, meuDestino) < 8)
            {   
                ///Para n�o dar Ruim
                numero++;
                if (numero > 4)
                {
                    numero = 0;
                    Destino = Destinos[numero];
                    
                }
                else
                {
                    
                    Destino = Destinos[numero];
                }
            }
        }
    }
}
