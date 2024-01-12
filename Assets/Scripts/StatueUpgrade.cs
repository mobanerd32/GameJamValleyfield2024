using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatueUpgrade : MonoBehaviour
{

    [SerializeField] private GameObject[] listeLVL;
    private int lvl = 0;

    [SerializeField] private Barricade[] listeBarricade;

    [SerializeField] private PlayerInfo infoDuJoueur;

    [SerializeField] private TMP_Text nbAdepte;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var lvl in listeLVL)
        {
            lvl.SetActive(false);
        }
        listeLVL[0].SetActive(true);
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade(){
        if(lvl<2 && infoDuJoueur.adepte >= 20){
            infoDuJoueur.adepte -= 20;
            listeLVL[lvl].SetActive(false);
            listeLVL[lvl + 1].SetActive(true);
            lvl++;
            nbAdepte.text = "Nombre D'adepte : " + infoDuJoueur.adepte;
        } 
    }

    public void RepairAll(){
        if(infoDuJoueur.adepte >= 10){
            infoDuJoueur.adepte -= 10;
            foreach (var barricade in listeBarricade)
            {
                barricade.Repair();
            }
            nbAdepte.text = "Nombre D'adepte : " + infoDuJoueur.adepte;
        }
        
    }
}
