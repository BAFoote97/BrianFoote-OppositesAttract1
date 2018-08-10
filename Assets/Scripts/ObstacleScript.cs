using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {

    public GameObject whatever;
    public Rigidbody myRigidBody;

    public float moveMin;
    public float moveMax;

    public float moveSpeed;
    public float delayToPush;

    public bool moveIndependent;

    public bool lightPickup;
    public bool darkPickup;

	// Use this for initialization
	void Start () {
        //moveSpeed = (Random.Range(moveMin, moveMax));
        //myRigidBody.AddForce(whatever.transform.forward * moveSpeed);
        StartCoroutine(PushObject());
        
    }

    // Update is called once per frame
    void Update () {
        //if (moveIndependent == false)
        //{
        //transform.Translate(0, -moveSpeed, 0);
        //myRigidBody.AddForce(whatever.transform.forward * moveSpeed);
        //}
        moveSpeed = (Random.Range(moveMin, moveMax));

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Border")
        {
            //Debug.Log("Hit border");
            Destroy(gameObject);
        }
    }

    IEnumerator PushObject()
    {
        myRigidBody.AddForce(whatever.transform.forward * moveSpeed);
        yield return new WaitForSeconds(delayToPush);
        StartCoroutine(PushObject());
    }

}
