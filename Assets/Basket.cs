using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    void Start()
    {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;                                           // a 

            // The Camera's z position sets how far to push the mouse into 3D
            // If this line causes a NullReferenceException, select the Main Camera
            // in the Hierarchy and set its tag to Main camera in the Inspector.
            mousePos2D.z = -Camera.main.transform.position.z;                        //b

        // Cconvert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);     //c

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Find out what hit this basket
        GameObject collidedWith = collision.gameObject;
        if ( collidedWith.CompareTag("Apple") )
        {
            Destroy(collidedWith);
            //  Increase the score
            scoreCounter.score += 100;
        }
    }
}
