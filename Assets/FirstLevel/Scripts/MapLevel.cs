using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevel : MonoBehaviour, IFollowable
{
    public int SceneIndex => sceneIndex;
    [SerializeField] int sceneIndex;

    public TargetType targetType;

    public TargetType GetTargetType()
    {
        return targetType;
    }
}
