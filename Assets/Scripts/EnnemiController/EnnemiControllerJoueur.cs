using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiControllerJoueur : MonoBehaviour
{

    [SerializeField] private GameObject _laCible;

    [SerializeField] private NavMeshAgent _agent;
    private Vector3 _positionDeLaCible;

    [SerializeField] private int hp;

    [SerializeField] private Animator animEnnemi;

    // Start is called before the first frame update
    void Start()
    {
        _laCible = GameObject.Find("Player");

        animEnnemi = GetComponent<Animator>();
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
                this.gameObject.SetActive(false);
            }
        }
    }
}
