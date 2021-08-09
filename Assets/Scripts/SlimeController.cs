using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public PolygonCollider2D pc;
    public Animator animator;

    public Transform target;
    public float range = 20;
    public float speed = 1;
    private bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pc = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);


        if(distance < range)
        {
            animator.SetBool("Walk", true);

            if (isFacingRight && target.transform.position.x < transform.position.x)
            {
                FlipSlime();
            }
            else if (!isFacingRight && target.transform.position.x > transform.position.x)
            {
                FlipSlime();
            }

            ChaseTarget();
        }

        animator.SetBool("Walk", false);
    }

    void ChaseTarget()
    {

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void FlipSlime()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
