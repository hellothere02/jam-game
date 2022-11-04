using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private float minOffset;
    [SerializeField] private float maxOffset;
    [SerializeField] private int number;

    //private SpriteRenderer spriteRenderer;
    Vector3 pos;


    private void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(transform.position);

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if(diference.x < 0)
        {
            Debug.Log("little");
            float rotateZ = Mathf.Atan2(diference.y, diference.x*-1) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rotateZ, minOffset, maxOffset));
        }
        else
        {
            Debug.Log("big");
            float rotateZ = Mathf.Atan2(diference.y, diference.x * -1) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rotateZ, minOffset, maxOffset));
        }
        
        

        //if(rotateZ > 90 )
        //{
        //    spriteRenderer.flipX = true;
        //    transform.localPosition = new Vector3(-0.02f, transform.localPosition.y, transform.localPosition.z);
        //}
        //else
        //{
        //    spriteRenderer.flipX = false;
        //    transform.localPosition = new Vector3(0.02f, transform.localPosition.y, transform.localPosition.z);
        //}

        //transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rotateZ, -45, 225));

        //if (Input.mousePosition.x > pos.x)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rotateZ, -45, 45));

        //}
        //if (Input.mousePosition.x < pos.x)
        //{
        //    Debug.LogError("dsd");
        //    transform.rotation = Quaternion.Euler(0, 0, -Mathf.Clamp(rotateZ, -45, 45));
        //}
        //if (GlobalStringVars.HorizontalAxis.Equals(0) == false)
        //{
        //    if (Input.GetAxis(GlobalStringVars.HorizontalAxis) > 0)
        //    {
        //        transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rotateZ, -45, 45));
        //    }
        //    else
        //    {
        //        transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rotateZ, -45, 135));
        //    }
        //}

        //Vector3 localScale = Vector3.one;

        //if(rotateZ > 90 || rotateZ < -90)
        //{
        //    spriteRenderer.flipX = true;
        //}
        //else
        //{
        //    spriteRenderer.flipX = false;
        //}
        //transform.localScale = localScale;
    }



    //private Vector3 MousePos;
    //private Vector3 pos;
    //private void Update()
    //{

    //    Vector3 Scale = new Vector3(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y), Mathf.Abs(transform.localScale.z));
    //    MousePos = -(Camera.main.WorldToScreenPoint(transform.position) - Input.mousePosition);
    //    transform.localScale = new Vector3(Scale.x * (MousePos.x / Mathf.Abs(MousePos.x)), Scale.y, Scale.z);
    //}

    //void LookAtCursor()
    //{
    //    if (Input.mousePosition.x < pos.x && facingRight) Flip();
    //    else if (Input.mousePosition.x > pos.x && !facingRight) Flip();
    //}



    //public KeyCode left = KeyCode.A;
    //public KeyCode right = KeyCode.D;
    ////public float speed = 1.5f;
    //public Camera mainCamera;
    //public bool facingRight = true; // на старте, персонаж смотрит вправо?
    //private Vector3 theScale;
    ////private Rigidbody2D body;
    //private Vector3 pos;
    //private float h;

    //void Awake()
    //{
    //	//body = GetComponent<Rigidbody2D>();
    //	theScale = transform.localScale;
    //}

    ////void FixedUpdate()
    ////{
    ////	// добавл€ем ускорение
    ////	body.AddForce(Vector2.right * h * speed * body.mass * 100);

    ////	if (Mathf.Abs(body.velocity.x) > speed) // если скорость тела превышает установленную, то выравниваем ее
    ////		body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
    ////}

    //// разворот относительно позиции курсора
    //void LookAtCursor()
    //{
    //	if (Input.mousePosition.x < pos.x && facingRight) Flip();
    //	else if (Input.mousePosition.x > pos.x && !facingRight) Flip();
    //}

    //void Update()
    //{
    //	if (Input.GetKey(left)) h = -1; else if (Input.GetKey(right)) h = 1; else h = 0;

    //	if (Input.GetMouseButton(1)) // если нажата ѕ ћ, персонаж будет двигатьс€ в сторону курсора
    //		if (facingRight) h = 1; else h = -1;

    //	// переносим позицию из мировых координат в экранные
    //	pos = mainCamera.WorldToScreenPoint(transform.position);

    //	if (h == 0) LookAtCursor();

    //	if (!Input.GetMouseButton(0)) // если Ћ ћ (стрельба) не нажата, разворот по вектору движени€
    //	{
    //		if (h > 0 && !facingRight) Flip(); else if (h < 0 && facingRight) Flip();
    //	}
    //	else
    //	{
    //		LookAtCursor();
    //	}
    //}

    //void Flip() // отразить по горизонтали
    //{
    //    facingRight = !facingRight;
    //    theScale.x *= -1;
    //    transform.localScale = theScale;
    //}
}
