using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiSound : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clipsCoupBat;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Arme"){
            int randomIndex = Random.Range(0, clipsCoupBat.Length);
            source.clip = clipsCoupBat[randomIndex];
            source.Play();
        }
    }
}
