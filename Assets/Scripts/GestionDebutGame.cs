using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionDebutGame : MonoBehaviour
{

    [SerializeField] public GameObject[] listeStatue;

    [SerializeField] private NomClan Clan;

    private GameObject thingOverRoad;

    // Start is called before the first frame update
    void Start()
    {
        SpawnStatue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnStatue(){
        Vector3 randomPosition = new Vector3(0, 0, 0);
 
        //update the y value depending on how much you want the thing to randomly rotate
        Quaternion Rotation = Quaternion.Euler(0, 0, 0);
 
        
        switch (Clan.nom)
        {
            case "Renard" :
                thingOverRoad = Instantiate(listeStatue[0], randomPosition, Rotation);
                break;
            case "Corbeau" :
                thingOverRoad = Instantiate(listeStatue[1], randomPosition, Rotation);
                break;
            case "Requin" :
                thingOverRoad = Instantiate(listeStatue[2], randomPosition, Rotation);
                break;
        }
    }
}
