using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiControllerStatue : MonoBehaviour
{
    [SerializeField] private GameObject _laCible;

    [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;
    private Vector3 _positionDeLaCible;

    [SerializeField] private int hp;

    [SerializeField] private Animator animEnnemi;

    [SerializeField] private EnnemiGenerator generator;

    // Start is called before the first frame update
    void Start()
    {
        _laCible = GameObject.Find("Statue");

        animEnnemi = GetComponent<Animator>();

        generator = GameObject.Find("EnnemiGenerator").GetComponent<EnnemiGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        BougerAgent();
    }

    void BougerAgent(){

        _positionDeLaCible = _laCible.transform.position;

        _agent.SetDestination(_positionDeLaCible);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Arme"){
            hp-= other.GetComponent<Weapon>().dmg;
            animEnnemi.SetTrigger("dmg");
            if(hp <= 0){
                generator.EnnemiEnVie--;
                this.gameObject.SetActive(false);
            }
        }
    }
}
