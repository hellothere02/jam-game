using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpHight = 0.5f;
    [SerializeField] private float movementInAir = 0.8f;
    [Header("Other settings")]
    [SerializeField] private Transform groundCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField, Range(0, 2)] private float circleRadius;
    [SerializeField, Range(0, 1)] private float circleRadiusIsInAir;
    [SerializeField] private AnimationCurve movementCurve;
    //[SerializeField] private GameObject sword;
    //[SerializeField] private Transform swordRightTransform;
    //[SerializeField] private Transform swordLeftTransform;
    //[SerializeField] GameObject deadPanel;
    private Vector2 currentSwordTransform;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject headRight;
    [SerializeField] private GameObject headleft;
    private Vector3 overlapCircle;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private bool inAttack;
    private bool isAllowedToJump;
    private bool isNotInAir;

    private bool _isStep = false;
    public static event OnStep Step;
    public delegate void OnStep(bool step);

    private bool _isJumpSound = false;
    public static event OnJump JumpSound;
    public delegate void OnJump(bool jump);

    private bool _isAlightingd = false;
    public static event OnAlightingd Alightingd;
    public delegate void OnAlightingd(bool alightingd);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(overlapCircle, circleRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(overlapCircle, circleRadiusIsInAir);
    }
    private void Awake()
    {
        headRight.SetActive(true);
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void Start()
    {
        Step(_isStep);
    }

    private void FixedUpdate()
    {
        overlapCircle = groundCollider.position;
        isAllowedToJump = Physics2D.OverlapCircle(overlapCircle, circleRadius, groundLayer);
        isNotInAir = Physics2D.OverlapCircle(overlapCircle, circleRadiusIsInAir, groundLayer);
    }

    public void Run(bool isMoving)
    {
        if (isNotInAir && isMoving)
        {
            animator.SetFloat("Velocity", Mathf.Abs(playerRigidbody.velocity.x));
            _isStep = false;
            Step(_isStep);
        }
        else
        {
            animator.SetFloat("Velocity", 0);
            _isStep=true;
            Step(_isStep);
        }
    }

    //public void Attack(bool isAttacking)
    //{
    //    if (isAttacking && isNotInAir)
    //    {
    //        //GameObject currentSword = Instantiate(sword, currentSwordTransform, Quaternion.Euler(0, 0, angle));
    //        //animator.SetBool("isAttacking", true);
    //        inAttack = true;
    //    }
    //    else
    //    {
    //        //animator.SetBool("isAttacking", false);
    //    }
    //}

    public void MovePlayer(float direction, bool isJumped, bool isMoving)
    {
        Jump(isJumped);

        if (Mathf.Abs(direction) > 0.01f)
        {
            MoveHorizontal(direction);
        }
        FlipPlayer(direction);
        Run(isMoving);
    }

    public void Jump(bool isJumped)
    {
        if (isJumped && isAllowedToJump && inAttack == false)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x * movementInAir, jumpHight);
        }

        if (playerRigidbody.velocity.y.Equals(0) == false && isJumped)
        {
            animator.SetBool("isJumping", true);
            _isJumpSound = true;
            JumpSound(_isJumpSound);

        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        if (isNotInAir == false)
        {
            animator.SetBool("inAir", true);
            animator.SetBool("isJumping", false);
            _isAlightingd = true;
            Alightingd(_isAlightingd);
        }
        else
        {
            animator.SetBool("inAir", false);
        }
    }

    public void MoveHorizontal(float direction)
    {
        if (inAttack == false)
        {
            playerRigidbody.velocity = new Vector2(movementCurve.Evaluate(direction), playerRigidbody.velocity.y);
        }
    }

    public void Dying()
    {
        //deadPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void FlipPlayer(float horizontalDirection)
    {
       
            if (horizontalDirection.Equals(0) == false)
            {
                if (horizontalDirection < 0)
                {
                    spriteRenderer.flipX = true;
                    headRight.SetActive(false);
                    headleft.SetActive(true);

                    //spriteRendererHead.flipX = true;
                    //spriteRendererLight.flipX = true;
                    //transformHead.localPosition = new Vector3(-0.02f, transformHead.localPosition.y, transformHead.localPosition.z);
                    //currentSwordTransform = new Vector2(swordLeftTransform.position.x, swordLeftTransform.position.y);
                    //angle = 180f;
                }
                else
                {
                    spriteRenderer.flipX = false;
                    headleft.SetActive(false);
                    headRight.SetActive(true);
                    //spriteRendererHead.flipX = false;
                    //spriteRendererLight.flipX = false;
                    //transformHead.localPosition = new Vector3(0.02f, transformHead.localPosition.y, transformHead.localPosition.z);
                    //currentSwordTransform = new Vector2(swordRightTransform.position.x, swordRightTransform.position.y);
                    //angle = 0;
                }
            }
        
    }

    public void EndOfAttack()
    {
        inAttack = false;
    }

#if UNITY_EDITOR
    [ContextMenu("Reset speed")]
    public void ResetSpeed()
    {
        jumpHight = 0.5f;
        movementInAir = 0.8f;
    }
#endif
}

