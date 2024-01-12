using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] listeEnnemi;
    
    GameObject thingOverRoad;

    private float TimerBetweenWave;

    private float TimerBetweenSpawn;

    [SerializeField] private float TempsEntreVague;

    [SerializeField] private float TempsEntreApparition;

    private bool WaveStart = true;

    [SerializeField] private int[] listeWaveSize;

    private int WaveNum;

    public int EnnemiEnVie;

    private int EnnemiSpawnedNum;
    // Start is called before the first frame update
    void Start()
    {
        TimerBetweenWave = TempsEntreVague;
        WaveNum = 0;
        SpawnEnnemi();
    }

    // Update is called once per frame
    void Update()
    {
        if(WaveStart == true && EnnemiSpawnedNum <= listeWaveSize[WaveNum]){
            TimerBetweenSpawn -= Time.deltaTime;
            if (TimerBetweenSpawn <= 0f)
            {
                SpawnEnnemi();
            }
        }
        else if(WaveStart == false){
            TempsEntreVague -= Time.deltaTime;
            if (TempsEntreVague <= 0f)
            {
                WaveStart = true;
            }
        }

        if(EnnemiEnVie <= 0){
            TimerBetweenWave = TempsEntreVague;
            WaveStart = false;
            WaveNum++;
        }
    }

    private void SpawnEnnemi(){
        int rnd = Random.Range(0,listeEnnemi.Length);

        //update the x & z values depending on the specific boundaries of your scene
        Vector3 randomPosition = new Vector3(Random.Range(-40, 40), 0.8f, Random.Range(-40, 40));
 
        //update the y value depending on how much you want the thing to randomly rotate
        Quaternion Rotation = Quaternion.Euler(0, 0, 0);
 
        thingOverRoad = Instantiate(listeEnnemi[rnd], randomPosition, Rotation);

        TimerBetweenSpawn = TempsEntreApparition;
        EnnemiEnVie++;
        EnnemiSpawnedNum++;
    }

    private void SpawnBoss(){

    }
}
