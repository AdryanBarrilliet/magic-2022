using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{


    public Transform target;
    float z;
    
    // Start is called before the first frame update
    void Start()
    {
        z = -transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        

         float angle = transform.rotation.eulerAngles.z;
         angle = (angle > 180) ? angle - 360 : angle;
         Vector3 relativePos = target.position - transform.position;
         Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);
         Quaternion LookAtRotationOnly_Y = Quaternion.Euler(LookAtRotation.eulerAngles.x, LookAtRotation.eulerAngles.y, z);
        // Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.e);

        transform.rotation = LookAtRotationOnly_Y;

        /*Vector3 lookVector = target.transform.position - transform.position;
        lookVector.z = transform.position.z;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);*/

        //Vector3 relativePos = target.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos,Vector3.zero);
        //transform.rotation = rotation;
        // transform.LookAt(new Vector3(transform.position.x, transform.position.y, transform.position.z));
        // transform.localRotation = Quaternion.Euler(0, player.transform, 0);
        //LookAt(player.transform);
    }
}
