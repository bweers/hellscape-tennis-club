using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
  private Rigidbody2D rb;
  private Camera cam;
  public GameObject tennisBallPrefab, ballSpawnPointObject;
  private float moveSpeed = 4.5f, timer = 0f;
  public float chargeDelay;
  private Vector2 moveDirection;
  public int charge, maxCharge = 30;
  private bool leftMouseDown;
 
    void Start()
    {
        StartCoroutine(ChargeTimer());
        GameObject ballSpawnPointObject = GameObject.Find("BallSpawnPoint");
    }
    
   void Awake()
   {
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

        //Mouse Button Held Down
        leftMouseDown = Input.GetMouseButton(0);
        timer += Time.deltaTime;
   }

   private IEnumerator ChargeTimer() {
         while (true) {
             yield return new WaitForSeconds(chargeDelay);

             //Checking left mouse down and incrementing charge or shooting ball
             if (leftMouseDown)
             {
                if (charge >= maxCharge)
                {
                    charge = maxCharge;
                }
                else {
                    charge++;
                }
                // Debug.Log(charge);
             }
             else if (charge > 0)
             {
                SpawnTennisBall();
                charge = 0;
             }
             else
             {
                 charge = 0;
             }
         }
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


    void SpawnTennisBall()
    {
        GameObject spawnedBall = Instantiate(tennisBallPrefab, ballSpawnPointObject.transform.position, Quaternion.identity);
        Rigidbody2D rb = spawnedBall.GetComponent<Rigidbody2D>();
        Vector3 direction = ballSpawnPointObject.transform.TransformDirection(Vector3.right);
        rb.velocity = new Vector2( direction.x * charge, direction.y * charge );
    }
}