using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IACacador : MonoBehaviour
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
            //Se a minha distancia para qualquer wayPoint menor que 8 
           if (Vector3.Distance(transform.position, meuDestino) < 8)
            {
                int n = Destinos.Count;
                numero = Random.Range(0, n);
                Destino = Destinos[numero];
            }
        }
        else
        {
            Destino = Tesouro;
            Vector3 meuDestino = Destino.transform.position;
            Agente.SetDestination(meuDestino);

        }
    }


    void OnTriggerEnter(Collider achou)
    {
        
        //Cruzei com meu Objetivo
        if (achou.gameObject.tag == "Tesouro")
        {
            objetivo = true;
            Tesouro = achou.gameObject;
        }
    }


}
