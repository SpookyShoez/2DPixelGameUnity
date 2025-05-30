using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir; 
    private Knockback knockback;

    private void Awake() {
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (knockback.GettingKnockedBack) { return; }
        
        rb.MovePosition(rb.position + moveDir * (speed * Time.fixedDeltaTime)); 
    }

    public void MoveTo(Vector2 targetPosition) {
        moveDir = targetPosition;
    }
}
