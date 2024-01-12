using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Statue : MonoBehaviour
{

    private int hp = 5;

    private float timerDegat = 5f;
    private bool Invincible;

    [SerializeField] private TMP_Text hpTextStatue;
    // Start is called before the first frame update
    void Start()
    {
        hpTextStatue.text = "Pv Statue : " + hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Invincible == true){
            timerDegat -= Time.deltaTime;
            if(timerDegat<= 0f){
                Invincible = false;
            }
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Ennemi" && Invincible == false){
            timerDegat = 5f;
            Invincible = true;
            hp--;
            hpTextStatue.text = "Pv Statue : " + hp;
            if(hp <= 0){
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
