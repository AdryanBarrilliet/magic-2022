using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInBack : MonoBehaviour
{
    public Transform target;

    void Update()
    {

        Vector3 localPositionInTargetSpace = target.transform.InverseTransformPoint(transform.position);
        bool active;
        if (localPositionInTargetSpace.z < 0)
            active = true;
        else
            active = false;

        //GetComponent<Renderer>().enabled = active;


        AudioSource source = GetComponent<AudioSource>();
        if (active)
            source.volume = 1;
        else
            source.volume = 0;
       

    }
}
