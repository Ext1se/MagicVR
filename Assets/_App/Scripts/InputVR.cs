using BNG;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace MobaVR
{
    [ShowOdinSerializedPropertiesInInspector]
    public class InputVR : MonoBehaviour
    {
        [Header("Base")]
        public InputBridge InputBridge;
        public BNGPlayerController BngPlayerController;
        public CharacterController CharacterController;

        [Header("Screen")]
        public BaseDamageIndicator DamageIndicator;
        
        [Header("PlayerController")]
        public Transform TrackingSpace;
        public Transform CameraRig;
        public Transform CenterEyeAnchor;
        
        [Space]
        [Header("IK")]
        public Transform IKHead;
        public Transform IKLeftHand;
        public Transform IKRightHand;

        [Space]
        [Header("Hand Controllers")]
        public HandController LeftController;
        public HandController RightController;
        public SkinnedMeshRenderer RightHandSkinnedMeshRenderer;
        public SkinnedMeshRenderer LeftHandSkinnedMeshRenderer;

        [Header("Left Hand Grabber")]
        public Grabber LeftGrabber;
        public Transform LeftBigFireballPoint;
        public Transform LeftSmallFireballPoint;

        [Header("Right Hand Grabber")]
        public Grabber RightGrabber;
        public Transform RightBigFireballPoint;
        public Transform RightSmallFireballPoint;
    }
}