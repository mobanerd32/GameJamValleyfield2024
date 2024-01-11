using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueUpgrade : MonoBehaviour
{

    [SerializeField] private GameObject[] listeLVL;
    private int lvl = 0;

    [SerializeField] private Barricade[] listeBarricade;

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
        if(lvl<2){
            listeLVL[lvl].SetActive(false);
            listeLVL[lvl + 1].SetActive(true);
            lvl++;
        } 
    }

    public void RepairAll(){
        foreach (var barricade in listeBarricade)
        {
            barricade.Repair();
        }
    }
}
