using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    private Vector3 _checkPointposition;
    private Rigidbody2D _rbPlayer;
    [SerializeField] LayerMask _layerMask;
    private RaycastHit2D hit;
    [SerializeField]
    private float _distance;
    [SerializeField]
    private LayerMask _goal;
    [SerializeField]
    private Animator _trapAnim;
    [SerializeField] private AudioSource _sounDeathPlayer;


    public bool _isDeat;

    public static event OnDeatPlayer Death;
    public delegate void OnDeatPlayer(bool death);

    //private bool _isdeath = false;
    //public static event OnDeath SoundDeath;
    //public delegate void OnDeath(bool death);
    void OnEnable()
    {
        ManagenetUIGame.ProceedGame += CheckPoint;
        WildPlant.DeathWild += DeathPlayerTrap;
        TrapDog.DeathDog += DeathPlayerTrap;
    }
    void OnDisable()
    {
        ManagenetUIGame.ProceedGame -= CheckPoint;
        WildPlant.DeathWild -= DeathPlayerTrap;
        TrapDog.DeathDog -= DeathPlayerTrap;
    }
    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
        _trapAnim = GetComponent<Animator>();
    }
    private void Update()
    {
        DeathPlayer();
    }

    private void DeathPlayer()
    {
        hit = Physics2D.Raycast(_rbPlayer.transform.position, Vector2.down, _distance, _goal);
    
        if (hit.collider != null)
        {

            if (hit.collider.CompareTag("Ground"))
                _checkPointposition = _rbPlayer.transform.position;
            _isDeat = false;
            
        } 

            if (_rbPlayer.transform.position.y < 0.35)
            {
                   _sounDeathPlayer.Play();
                _isDeat = true;
                //Death(_isDeat);

              //SoundDeath(_isDeat);
                Death(_isDeat);
            }
   
    }
    private void CheckPoint(bool ischeckPoint)
    {
        if (ischeckPoint)
            _rbPlayer.transform.position =_checkPointposition;
        _rbPlayer.velocity = Vector3.zero;
    }
    

    private void  DeathPlayerTrap(bool activ)
    {
        if (activ)
        {
            StartCoroutine("DeathTrap");
        }
    
    }
    private IEnumerator DeathTrap()
    {       
            float anim = _trapAnim.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(anim + 0.5f);
            _isDeat = true;
            Death(_isDeat);       
    }
}

    

