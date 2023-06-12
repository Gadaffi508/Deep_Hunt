using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCameraControl : MonoBehaviour, IFollowable
{
    public static BoatCameraControl instance;

    public TargetType targetType;

    public TargetType GetTargetType() => targetType;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CameraManager.instance.Target = this.transform;
    }
}
