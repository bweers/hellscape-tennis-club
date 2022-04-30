using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIController : MonoBehaviour
{
    // Brackeys Turtorial: https://www.youtube.com/watch?v=jvtFUfJ6CP8
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    private Vector2 direction;

    public Transform monsterSprite;
    
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path P)
    {
        if(!P.error)
        {
            path = P;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        monsterSprite.rotation = Quaternion.Euler(0f,0f, angle + 90);
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
        }
        else
        {
            reachedEndOfPath = false;
        }
    
        
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f && force.x > 0f)
        {
            monsterSprite.localScale = new Vector3(-1f, 1, 1f);
        }
        else if (rb.velocity.x <= -0.01f && force.x < 0f)
        {
            monsterSprite.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
