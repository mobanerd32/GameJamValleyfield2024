using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{

    [SerializeField] private GameObject[] NiveauDeDMG;

    [SerializeField] private int Starthp;

    private int hp;

    [SerializeField] private int hpDamaged;

    private float TimerInvincible = 2f;

    private bool Invincible = false;

    private int ActivatedModelIndex;

    private Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        foreach (var Barricade in NiveauDeDMG)
        {
            Barricade.SetActive(false);
        }
        NiveauDeDMG[0].SetActive(true);
        ActivatedModelIndex = 0;
        hp = Starthp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Invincible == true){
            TimerInvincible -= Time.deltaTime;
            if(TimerInvincible <= 0){
                Invincible = false;
                TimerInvincible = 2f;
            }
        }
    }

    /// <summary>
    /// OnCollisionStay is called once per frame for every collider/rigidbody
    /// that is touching rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionStay(Collision other)
    {
        if(other.transform.tag == "Ennemi" && Invincible == false){
            
            Invincible = true;
            hp--;

            if(hp <= hpDamaged && hp > 0 && NiveauDeDMG.Length > 2){
                NiveauDeDMG[0].SetActive(false);
                NiveauDeDMG[1].SetActive(true);
                ActivatedModelIndex = 1;
            }
            else if(hp<=0){
                NiveauDeDMG[ActivatedModelIndex].SetActive(false);
                NiveauDeDMG[NiveauDeDMG.Length -1].SetActive(true);
                collider.enabled = false;
            }
        }
    }

    private void Repair(){
        collider = GetComponent<Collider>();
        foreach (var Barricade in NiveauDeDMG)
        {
            Barricade.SetActive(false);
        }
        NiveauDeDMG[0].SetActive(true);
        ActivatedModelIndex = 0;
        hp = Starthp;
        collider.enabled = true;
    }
}
