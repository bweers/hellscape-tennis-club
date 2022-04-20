using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
  private PlayerInputActions playerInput;
  private Rigidbody2D rb;
  private float speed = 10f;
  private Camera cam;
 
   void Awake()
   {
       playerInput = new PlayerInputActions();
       rb = GetComponent<Rigidbody2D>();
       cam = Camera.main;
   }

   private void OnEnable()
   {
     playerInput.Enable();  
   }

   private void OnDisable()
   {
       playerInput.Disable();
   }

   void FixedUpdate()
   {
       Vector2 moveInput = playerInput.Movement.Move.ReadValue<Vector2>();
       rb.velocity = moveInput * speed;

      // LookAtMouse
       Vector3 mouse = Input.mousePosition;
       Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
       Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
       float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.Euler(0f,0f, angle);
   }
}