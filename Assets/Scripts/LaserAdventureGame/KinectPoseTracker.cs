
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Windows.Kinect;


public class KinectPoseTracker : MonoBehaviour
{
    [SerializeField] private BodySourceManager bodySourceManager;
    [SerializeField] private AvatarBoneRotator rotator;


    void FixedUpdate()
    {

        Body[] bodies = bodySourceManager.GetData();
        if (bodies == null)
        {
            return;
        }

        Body body = bodies.FirstOrDefault(b => b.IsTracked);

        if (body != null)
        {
            var joints = body.JointOrientations;

            rotator.RotateBone(HumanBodyBones.Spine, joints[JointType.SpineBase].Orientation.ToQuaternion());
            rotator.RotateBone(HumanBodyBones.Chest, joints[JointType.SpineMid].Orientation.ToQuaternion());
            rotator.RotateBone(HumanBodyBones.UpperChest, joints[JointType.SpineShoulder].Orientation.ToQuaternion());

            rotator.RotateBone(HumanBodyBones.LeftShoulder, joints[JointType.ShoulderLeft].Orientation.ToQuaternion());
            rotator.RotateBone(HumanBodyBones.RightShoulder, joints[JointType.ShoulderRight].Orientation.ToQuaternion());

            rotator.RotateBone(HumanBodyBones.LeftLowerArm, joints[JointType.ElbowLeft].Orientation.ToQuaternion());
            rotator.RotateBone(HumanBodyBones.LeftHand, joints[JointType.WristLeft].Orientation.ToQuaternion());
            // HandLeft = joints[JointType.HandLeft].Orientation.ToQuaternion( );

            rotator.RotateBone(HumanBodyBones.RightLowerArm, joints[JointType.ElbowRight].Orientation.ToQuaternion());
            rotator.RotateBone(HumanBodyBones.RightHand, joints[JointType.WristRight].Orientation.ToQuaternion());
            // HandRight = joints[JointType.HandRight].Orientation.ToQuaternion( );
            // rotator.RotateBone(HumanBodyBones.LeftUpperLeg, joints[JointType.HipLeft].Orientation.ToQuaternion( ));
            rotator.RotateBone(HumanBodyBones.LeftLowerLeg, joints[JointType.KneeLeft].Orientation.ToQuaternion());
            rotator.RotateBone(HumanBodyBones.LeftFoot, joints[JointType.AnkleLeft].Orientation.ToQuaternion());

            // rotator.RotateBone(HumanBodyBones.RightUpperLeg, joints[JointType.HipRight].Orientation.ToQuaternion( ));
            rotator.RotateBone(HumanBodyBones.RightLowerLeg, joints[JointType.KneeRight].Orientation.ToQuaternion());
            rotator.RotateBone(HumanBodyBones.RightFoot, joints[JointType.AnkleRight].Orientation.ToQuaternion());
        }
    }
}