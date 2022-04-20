using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
  private PlayerInputActions playerInput;
  private Rigidbody2D rb;
  private float speed = 10f;
 
   void Awake()
   {
       playerInput = new PlayerInputActions();
       rb = GetComponent<Rigidbody2D>();
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
   }
}