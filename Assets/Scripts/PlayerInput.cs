using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private float horizontalDirection;
    //private bool isAttacking;
    private bool isJumped;
    private bool isMoving;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        horizontalDirection = Input.GetAxis(GlobalStringVars.HorizontalAxis);
        isMoving = Input.GetButton(GlobalStringVars.HorizontalAxis);
        isJumped = Input.GetButtonDown(GlobalStringVars.JumpButton);
        //isAttacking = Input.GetButtonDown(GlobalStringVars.FireButton);
        playerMovement.MovePlayer(horizontalDirection, isJumped, isMoving);
        //playerMovement.Attack(isAttacking);
    }
}


