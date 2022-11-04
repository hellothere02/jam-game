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
   

    private bool _isDeat;

    public static event OnDeatPlayer Death;
    public delegate void OnDeatPlayer(bool death);
    void OnEnable()
    {
        ManagenetUIGame.ProceedGame += CheckPoint;
    }
    void OnDisable()
    {
        ManagenetUIGame.ProceedGame -= CheckPoint;
    }
    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
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
       
        if (_rbPlayer.transform.position.y < -3)
        {
            _isDeat = true;
            Death(_isDeat);
        }

    }
    private void CheckPoint(bool ischeckPoint)
    {
        if (ischeckPoint)
            _rbPlayer.transform.position =_checkPointposition;
        _rbPlayer.velocity = Vector3.zero;
    }




}