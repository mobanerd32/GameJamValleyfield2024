using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUp : MonoBehaviour
{
    
    [SerializeField] public GameObject[] listePowerUp;
    
    GameObject thingOverRoad;

    private float Timer;

    [SerializeField] private float TempsTimer;
   
    void SpawnPowerUp()
    {

        int rnd = Random.Range(0,2);

        //update the x & z values depending on the specific boundaries of your scene
        Vector3 randomPosition = new Vector3(Random.Range(-50, 50), 0.8f, Random.Range(-50, 50));
 
        //update the y value depending on how much you want the thing to randomly rotate
        Quaternion Rotation = Quaternion.Euler(0, 0, 0);
 
        thingOverRoad = Instantiate(listePowerUp[rnd], randomPosition, Rotation);

        Timer = TempsTimer;
    }

    private void Start()
    {
        Timer = TempsTimer;
    }
 
    private void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            SpawnPowerUp();
        }
    }
}
