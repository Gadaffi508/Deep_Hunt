using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    private Camera cam;

    public float followSpeed;

    private Vector3 startingPosition;
    private float yOffset;

    private Transform target;
    public Transform Target { get { return target; } 
        set 
        {
            target = value;

            IFollowable targetFollowable = target?.GetComponent<IFollowable>();

            if (targetFollowable != null)
                targetType = targetFollowable.GetTargetType();
        } 
    }

    private TargetType targetType;

    private void Awake()
    {
        instance = this;

        cam = GetComponent<Camera>();
    }
    private void Start()
    {
        startingPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (target is null) return;

        if(targetType is TargetType.MapLevel)
        {
            yOffset = target.position.y;
        }
        else if(targetType is TargetType.Ship)
        {
            yOffset = startingPosition.y;
        }

        Vector3 followPosition = new Vector3(target.position.x, yOffset, startingPosition.z);

        transform.position = Vector3.Lerp(transform.position, followPosition, followSpeed * Time.deltaTime);

    }

}
