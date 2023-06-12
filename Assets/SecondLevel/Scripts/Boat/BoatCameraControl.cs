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
        CameraSet();

    }
    private void OnEnable()
    {
        MapManager.instance.OnSceneChanged += CameraSet;
    }
    private void OnDisable()
    {
        MapManager.instance.OnSceneChanged -= CameraSet;
    }

    public void CameraSet()
    {
        CameraManager.instance.Target = this.transform;
    }
}
