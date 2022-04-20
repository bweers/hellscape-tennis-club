using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
  // private PlayerInputActions playerInput;
  private Rigidbody2D rb;
  public float moveSpeed = 8f;
  private Camera cam;
  private Vector2 moveDirection;
 
   void Awake()
   {
      //  playerInput = new PlayerInputActions();
       rb = GetComponent<Rigidbody2D>();
       cam = Camera.main;
   }

   void Update()
   {
     ProcessInputs();
   }

   void FixedUpdate()
   {
      Move();

      // LookAtMouse
       Vector3 mouse = Input.mousePosition;
       Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
       Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
       float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.Euler(0f,0f, angle);
   }

   void Move() 
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

   void ProcessInputs() 
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }
}