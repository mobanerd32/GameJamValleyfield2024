using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerInfo infoDuJoueur; 
     //SerializeField est utiliser pour manipuler les variables dans l'inspecteur
    [SerializeField] private float _vitesse = 1f;
    [SerializeField] private float _forceSaut = 5f; //Il faut une référence a un autre gameobject pour y accéder
    private float timerDegat = 3f;

    //les variable bool permette de vérifier la condition de notre gameobject
    private bool _isGrounded;
    private bool _doubleJump;

    private bool _blocking;

    // les variables float permette de manipuler des chiffre et peuvent etre utilisé avec les Vector3
    private float _mouvementHorizontal;
    private float _mouvementAvant;
    private float _mouvementHaut;


    //le Rigidbody est utiliser pour appliquer la physique au objet
    private Rigidbody _rb;
    private Vector2 _mouseDelta;
    private float _deltaRotationX;
    private float _deltaRotationY;

    private float _vitesseFinal;
    private bool _courir;
    private float _multiplicateurCourse = 2f;

    [Tooltip("Le délai en secondes entre les bruits de pas si on marche")]
    [SerializeField] private float _delaiBruitPasMarche = 1.0f;
    [Tooltip("Le délai en secondes entre les bruits de pas si on court")]
    [SerializeField] private float _delaiBruitPasCourse = 1.0f;
    private float _compteurDeTempsBruitsPas = 0.0f;


    [Range(-45, -15)]
    public int minAngle = -30;
    [Range(30, 80)]
    public int maxAngle = 45;
    [Range(10, 100)]
    [SerializeField] private float _sensibiliteSouris;

    [SerializeField]  private Animator _ArmeAnimator;


    

    //Le start est appellé seulement eu tout début, parfait pour récupérer les rigidbody de nos objet
    void Start()
    {
       _rb = GetComponent<Rigidbody>();
       //_audioSource = GetComponent<AudioSource>();
    }

    //TOUJOURS UTILISER FIXEDUPDATE AVEC LA PHYSIQUE
    void FixedUpdate() 
    {
        Bouge();
        Block();

        /*if (_SangEffet.activeSelf)
        {
            timerDegat -= Time.deltaTime;
            if (timerDegat <= 0f)
            {
                desactiveSang();
            }
        }*/
    }

    public void OnPause(InputValue value){
        //_PannelSon.SetActive(true);
    }


    //-----------------------------------

    //On move permet de détecter lorsqu'une touche est appuyé
    public void OnMove(InputValue value)
    {
        Vector2 _touchesClavier = value.Get<Vector2>();
        _mouvementHorizontal = _touchesClavier.x;
        _mouvementAvant = _touchesClavier.y;

        
    }

    // A rajouter dans le input system
    // permet de détecter si le jouer appuie sur espace
    public void OnJump(InputValue value){ 
       if(_isGrounded && _doubleJump)
        {
            _rb.AddForce(Vector3.up * _forceSaut, ForceMode.Impulse);
            _isGrounded = false;
            /*_audioSource.clip = _sonSaut;
            _audioSource.Play();*/
        }
        else if(!_isGrounded && _doubleJump){
             _rb.AddForce(Vector3.up * _forceSaut, ForceMode.Impulse);
            _doubleJump = false;
           /* _audioSource.clip = _sonSaut;
            _audioSource.Play();*/
        }

        
        
    }

    // vérifie la collision avec un objet et mets en parametre la collision qui a causé la méthode de s'activer
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Sol") /// Trigger other.tag   Collision other.transform.tag
        {
            _isGrounded = true;
            _doubleJump = true;
        }
        else if(other.transform.tag == "Health"){
            if(infoDuJoueur.hp + 10 > 100){
                infoDuJoueur.hp = 100;
            }
            else{
                infoDuJoueur.hp += 10;
            }
            Destroy(other.gameObject);
        }
        /*else if(other.transform.tag == "Savon"){
            if(_mainvide == true){
                other.gameObject.SetActive(false);
                _SavonDansMain.SetActive(true);
                _mainvide = false;
                _CollecteSavon.Play();
            } 
        }*/
        /*else if(other.transform.tag == "Canard" && !_mainvide && other.gameObject.GetComponent<Canard>().EstHuile == true){  
            _CanardAnimator = other.gameObject.GetComponent<Animator>();
            _CanardAnimator.SetBool("Commencer Huile",true);
            _SavonDansMain.SetActive(false);
            _mainvide = true;
            other.gameObject.GetComponent<Canard>().EstHuile = false;
            _audioSource.clip = _LaverCanard;
            _audioSource.Play();
        }*/
        /*else if(other.transform.tag == "Monster"){
            _Degat.Play();
            _SangEffet.SetActive(true);
        }*/
    }
    
    void OnRun(InputValue value)
    {
        if(value.isPressed)
        {
            _courir = true;
        }
        else
        {
            _courir = false;
        }
    }

    // exemple de méthode pour bouger en utilisant le rigidbody
    private void Bouge()
    {

        //------------VELOCITÉ

        /*Vector3 _direction =  Vector3.forward.normalized;
        _rb.velocity = transform.TransformDirection(_direction * _vitesse * _mouvementAvant);*/
        if (_courir)
        {   
            _multiplicateurCourse = 2f;
        }
        else
        {
            _multiplicateurCourse = 1f;
        }

        if (_mouvementHorizontal != 0 || _mouvementAvant != 0)
        {
            //Si le personnage est au sol
            /*if (_isGrounded)
            {
                JouerBruitsDePas();
            }*/
        }

        
       Vector3 globalVelocity = transform.TransformDirection(_mouvementHorizontal * _vitesse * _multiplicateurCourse,0,_mouvementAvant * _vitesse * _multiplicateurCourse);

       _rb.velocity = new Vector3(globalVelocity.x, _rb.velocity.y, globalVelocity.z);

    }

    void OnLook(InputValue value)
    {
        //Delta représente la quantité de mouvement de la souris dans les deux axe (X et Y) depuis la dernière lecture
        Vector2 delta = value.Get<Vector2>();

        //Calcul la quantité de rotation à effectuer dans l'axe X et Y selon la sensibilité de la souris
        _deltaRotationY = delta.x * _sensibiliteSouris * Time.fixedDeltaTime;
        _deltaRotationX = delta.y * _sensibiliteSouris * Time.fixedDeltaTime;

        //Récupère l'orientation local du joueur
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        
        //Convertir une rotation de 0 à 360 degrés vers -180 à 180 degrés
        float rotationX = convertirRotationEn180Degres(currentRotation.x - _deltaRotationX);

        //On limite la rotation entre degr.s afin d'.viter de faire un tour complet haut/bas
        rotationX = Mathf.Clamp(rotationX, minAngle, maxAngle);
        
        //Calcul la nouvelle rotation dans l'axe Y
        float rotationY = currentRotation.y + _deltaRotationY;

        //On applique la rotation X et Y au composent transform de l'objet où se trouve ce script
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    private float convertirRotationEn180Degres(float valeurRotation)
    {
        float rotationFinale;

        if(valeurRotation > 180f) {
            rotationFinale = valeurRotation - 360f;
        }
        else {
            rotationFinale = valeurRotation;
        }

        return rotationFinale;
    }

    /*private void desactiveSang(){
        _SangEffet.SetActive(false);
        timerDegat = 3f;
    }*/

    /*void JouerBruitsDePas()
    {
        // Incrémenter le compteur de temps
        _compteurDeTempsBruitsPas += Time.deltaTime;
        
        //Initialise une variable qui va contenir le délai avant de jouer le son à nouveau
        float delai = 0;

        //Affecte le bon délai selon si le personne court ou pas
        if (_courir)
        {
            delai = _delaiBruitPasCourse;
        }
        else
        {
            delai = _delaiBruitPasMarche;
        }

        // Vérifier si le délai est écoulé
        if (_compteurDeTempsBruitsPas > delai)
        {   
            //Fait jouer un son aléatoire dans la liste de son de bruits de pas
            int randomIndex = Random.Range(0, _listeBruitsPas.Length);
            _audioSource.clip = _listeBruitsPas[randomIndex];
            _audioSource.Play();

            // Réinitialiser le compteur de temps
            _compteurDeTempsBruitsPas = 0.0f;
        }

        
    }*/


    void OnFire(InputValue value){
         _ArmeAnimator.SetTrigger("Attaque");
    }

    void OnBlock(InputValue value){
        if(value.isPressed)
        {
            _blocking = true;
        }
        else
        {
            _blocking = false;
        }
    }

    private void Block(){
        if(_blocking == true){
            _ArmeAnimator.SetBool("Blocking",true);
            infoDuJoueur.ResistanceStatus = true;
        }
        else{
            _ArmeAnimator.SetBool("Blocking",false);
            infoDuJoueur.ResistanceStatus = false;
        }
    }

}

