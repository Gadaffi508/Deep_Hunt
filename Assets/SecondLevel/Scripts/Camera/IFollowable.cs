using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType { MapLevel, Ship }

public interface IFollowable
{
    public TargetType GetTargetType();
}
