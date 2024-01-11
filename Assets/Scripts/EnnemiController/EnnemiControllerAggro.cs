using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiControllerAggro : MonoBehaviour
{
   
    [SerializeField] private GameObject _laCible;

    [SerializeField] private NavMeshAgent _agent;
    private Vector3 _positionDeLaCible;

    [SerializeField] private GameObject[] listeDeCible;

    [SerializeField] private int hp;

    private float timerDegat;

    [SerializeField] private float TimerDegatReset;

    private bool AggroJoueur;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BougerAgent();

        if (AggroJoueur == true)
        {
            timerDegat -= Time.deltaTime;
            if (timerDegat <= 0f)
            {
                desactiveAggroJoueur();
            }
        }    
    }

    void BougerAgent(){

        _positionDeLaCible = _laCible.transform.position;

        _agent.SetDestination(_positionDeLaCible);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Arme"){
            hp-= other.GetComponent<Weapon>().dmg;
            ActiveAggroJoueur();
            if(hp <= 0){
                this.gameObject.SetActive(false);
            }
        }
    }

    private void ActiveAggroJoueur(){
        _laCible = listeDeCible[0];
        AggroJoueur = true;
        timerDegat = TimerDegatReset;
    }

    private void desactiveAggroJoueur(){
        _laCible = listeDeCible[1];
        AggroJoueur = false;
        timerDegat = TimerDegatReset;
    }
}
