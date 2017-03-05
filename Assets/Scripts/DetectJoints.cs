using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour {

    public GameObject BodySrcManager;
    public JointType TrackedJoint;
    private BodySourceManager bodyManager;
    private Body[] bodies;

    private float multiplier = 10f;
    
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
        /*if(bodyManager ==  null)
        {
            return;
        }
        bodies = bodyManager.GetData();

        if(bodies == null)
        {
            return;
        }
        foreach(var body in bodies)
        {
            if (body == null)
                continue;
            if (body.IsTracked)
            {
                var pos = body.Joints[TrackedJoint].Position;
                gameObject.transform.position = new Vector3(multiplier*pos.X,multiplier*pos.Y);
            }
        }*/
        /*Vector2 pos = transform.position;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            pos = new Vector2(pos.x, pos.y + multiplier * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pos = new Vector2(pos.x, pos.y - multiplier * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            pos = new Vector2(pos.x - multiplier * Time.deltaTime, pos.y);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            pos = new Vector2(pos.x + multiplier * Time.deltaTime, pos.y);
        }

        gameObject.transform.position = pos;*/


        float hAxis = Input.GetAxis("Horizontal");
        float vaxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, vaxis, 0) * multiplier * Time.deltaTime;

        gameObject.transform.position += movement;
    }
}
