using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionClan : MonoBehaviour
{

    [SerializeField] private NomClan clan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClan(string nomClan){
        clan.nom = "nomclan";
        SceneManager.LoadScene("Alpha V1");
    }
}
