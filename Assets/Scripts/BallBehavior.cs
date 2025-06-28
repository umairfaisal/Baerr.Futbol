using UnityEngine;
using System.Collections;
public class BallBehavior : MonoBehaviour 
{
    private Transform player;
    private PlayerBehavior playerBehavior;
    private bool isAttached = false;
    private bool isCooldown = false;
    public float cooldownTime = 1.0f;
    public float attachDistance = 1f;
    public float kickForce = 5f;
    public float KickNormalize;
    
    void Start() 
    { 
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerBehavior = player.GetComponent<PlayerBehavior>();
    } 
    void OnCollisionEnter(Collision collision) 
    { 
        if (collision.gameObject.CompareTag("Player") && !isAttached && !isCooldown) 
        { 
            AttachToPlayer();
        } 
    } 
    void AttachToPlayer() 
    { 
        transform.SetParent(player);
        transform.localPosition = new Vector3(1, -1, 0);
        GetComponent<Rigidbody>().isKinematic = true;
        isAttached = true;
    } 
    public void Kick() 
    { 
        if (isAttached) 
        { 
            transform.SetParent(null);
            GetComponent<Rigidbody>().isKinematic = false;
            isAttached = false;
        } 
        Rigidbody ballRigidbody = GetComponent<Rigidbody>();
        bool facingRight = playerBehavior.IsFacingRight();
        Vector3 kickDirection = facingRight ? Vector3.right : Vector3.left;
        Vector3 kickAngle = playerBehavior.Angle;
        ballRigidbody.AddForce(kickAngle * kickForce, ForceMode.Impulse);
        //ballRigidbody.AddForce(kickDirection * kickForce, ForceMode.Impulse);
        StartCoroutine(Cooldown()); 
    } 
    
    IEnumerator Cooldown() 
    {
        isCooldown = true;
        GetComponent<Rigidbody>().detectCollisions = false;
        yield return new WaitForSeconds(cooldownTime);
        GetComponent<Rigidbody>().detectCollisions = true;
        isCooldown = false;
        if  (Vector3.Distance(transform.position, player.position) <= attachDistance) 
        { 
            AttachToPlayer();
        } 
    } 
    
    void OnCollisionStay(Collision collision) 
    { 
        if (collision.gameObject.CompareTag("Player") && !isAttached && !isCooldown)
        { 
            AttachToPlayer();
        } 
    }
}