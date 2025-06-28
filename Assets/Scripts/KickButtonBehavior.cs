using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KickButtonBehavior : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Ball;
    public GameObject KickButtonPressed;
    public GameObject KickButtonReleased;
    private bool facingRight = true;
    public float kickForce = 10f;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (KickButtonPressed != null && Ball != null && Ball.transform.parent != null)
        {
            Rigidbody ballRigidbody = Ball.GetComponent<Rigidbody>();
            
            if (ballRigidbody != null)
            {
                Ball.transform.SetParent(null);

                Vector3 kickDirection = facingRight ? Vector3.right : Vector3.left;
                ballRigidbody.isKinematic = false;

                ballRigidbody.AddForce(kickDirection * kickForce, ForceMode.Impulse);

                // Start the cooldown period
                StartCoroutine(Cooldown(ballRigidbody));
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (KickButtonReleased != null)
        {
            // No need to set the ball's Rigidbody to kinematic here
        }
    }

    IEnumerator Cooldown(Rigidbody ballRigidbody)
    {
        // Disable collision detection for 0.5 seconds
        ballRigidbody.detectCollisions = false;
        yield return new WaitForSeconds(0.5f);
        ballRigidbody.detectCollisions = true;
    }
}
