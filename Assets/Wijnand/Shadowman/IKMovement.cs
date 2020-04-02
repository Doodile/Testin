using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKMovement : MonoBehaviour
{
    HumanPoseHandler humanPoseHandler;
    HumanPose humanPose;
    Animator anim;
    Transform head;
    public float val;
    [Range(0,10)]
    public float DistanceToGround;
    public LayerMask layerMask;

 



    void LookUpMuscleIndex()
    {
        string[] muscleName = HumanTrait.MuscleName;
        int i = 0;
        while (i < HumanTrait.MuscleCount)
        {
            Debug.Log(i + ": " + muscleName[i] +
                " min: " + HumanTrait.GetMuscleDefaultMin(i) + " max: " + HumanTrait.GetMuscleDefaultMax(i));
            i++;
        }
    }


    void Start()
    {
       
        anim = GetComponent<Animator>();
      
    }






    private void OnAnimatorIK(int layerIndex)
    {

        if (anim)
        {
      

            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, anim.GetFloat("IKLeftFootWeight"));
            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, anim.GetFloat("IKLeftFootWeight"));
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, anim.GetFloat("IKRightFootWeight"));
            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, anim.GetFloat("IKRightFootWeight"));

            // Left Foot
            RaycastHit hit;
            
            Ray ray = new Ray(anim.GetIKPosition(AvatarIKGoal.LeftFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, DistanceToGround + 1f, layerMask))
            {

             
                if (hit.transform.tag == "Walkable")
                {

                    Vector3 footPosition = hit.point; 
                    footPosition.y += DistanceToGround;
                    anim.SetIKPosition(AvatarIKGoal.LeftFoot, footPosition);
                    anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.LookRotation(transform.forward, hit.normal));

                }

            }

            // Right Foot
            ray = new Ray(anim.GetIKPosition(AvatarIKGoal.RightFoot) + Vector3.up, Vector3.down);
            if (Physics.Raycast(ray, out hit, DistanceToGround + 1f, layerMask))
            {

                if (hit.transform.tag == "Walkable")
                {

                    Vector3 footPosition = hit.point;
                    footPosition.y += DistanceToGround;
                    anim.SetIKPosition(AvatarIKGoal.RightFoot, footPosition);
                    anim.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.LookRotation(transform.forward, hit.normal));

                }

            }


        }
    }

}
    