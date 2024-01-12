using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{

    [Range(0,100)]
    public int hp;
    public int adepte;
    [SerializeField] private TMP_Text adepteCounter;
    [SerializeField] private TMP_Text hpText;
    public bool ResistanceStatus;

    public string clan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        adepteCounter.text = "Adepte : " + adepte;
        hpText.text = "HP : " + hp;
    }

   
    
}
