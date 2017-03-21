using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour {

    public GameObject BodySrcManager;
    public JointType RightHand;
    public JointType LeftHand;
    public JointType LeftElbow;
    private BodySourceManager bodyManager;
    private Body[] bodies;

    private int bodyIndex;



    private bool bodyTracked = false;

    private float multiplier = 12f;
    
    // Use this for initialization
    void Start () {
       
        if (BodySrcManager == null)
        {
            Debug.Log("Ne pas oublier d'assigner l'objet dans Unity avec Body Source Manager");
        }
        else
        {
            bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
           
        }


	}
	
	// Update is called once per frame
	void Update () {
       if(bodyManager ==  null)
        {
            return;
        }
        bodies = bodyManager.GetData();

        if(bodies == null)
        {
            return;
        }
        var body = this.bodies[0];
            if (body.IsTracked)
            {
                var pos = body.Joints[RightHand].Position;
                gameObject.transform.position = new Vector3(multiplier*pos.X,multiplier*pos.Y);
                if(body.Joints[LeftHand].Position.Y > body.Joints[LeftElbow].Position.Y )
                {
                    Debug.Log("OnHealRequest()");
                }
            }
    }
           /*   
=======
        } 
        /*      
>>>>>>> 9556cd6cb156b1a45c307f69762677fe43bcf54d
        float hAxis = Input.GetAxis("Horizontal");
        float vaxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, vaxis, 0) * multiplier * Time.deltaTime;
<<<<<<< HEAD

=======
        
>>>>>>> 9556cd6cb156b1a45c307f69762677fe43bcf54d
        gameObject.transform.position += movement;
        */
}
