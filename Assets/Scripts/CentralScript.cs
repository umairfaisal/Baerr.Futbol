using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CentralScript : MonoBehaviour
{
    private Vector3 BallInitialPos;
    private Vector3 PlayerInitialPos;
    public GameObject playerObject;
    public GameObject ballObject;

    private void Start()
    {
        BallInitialPos = ballObject.transform.position;
        
        PlayerInitialPos = playerObject.transform.position;
        
    }
    public void ResetButtonPressed()
    {
        ballObject.transform.position = BallInitialPos;
        
        ballObject.GetComponent<Rigidbody>().isKinematic = false;
        
        playerObject.transform.position = PlayerInitialPos;
        
    }

}
