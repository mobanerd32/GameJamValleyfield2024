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
        hp = 100;
        adepte = 0;
    }

    // Update is called once per frame
    void Update()
    {
        adepteCounter.text = adepte.ToString();
        hpText.text = "HP : " + hp;
    }

   
    
}
