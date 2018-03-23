using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEasing : MonoBehaviour
{
    protected enum EasingType { LINEAR, EXPOOUT, EXPOIN, EXPOINOUT, EXPOOUTIN,
                                CIRCOUT, CIRCIN, CIRCINOUT, CIRCOUTIN, QUADOUT,
                                QUADIN, QUADINOUT, QUADOUTIN, SINEOUT, SINEIN,
                                SINEINOUT, SINEOUTIN, CUBICOUT, CUBICIN, CUBICINOUT,
                                CUBICOUTIN, QUARTOUT, QUARTIN, QUARTINOUT, QUARTOUTIN,
                                QUINTOUT, QUINTIN, QUINTINOUT, QUINTOUTIN, ELASTICOUT,
                                ELASTICIN, ELASTICINOUT, ELASTICOUTIN, BOUNCEOUT, BOUNCEIN,
                                BOUNCEINOUT, BOUNCEOUTIN, BACKOUT, BACKIN, BACKINOUT, BACKOUTIN }
    [SerializeField]
    protected EasingType type;

    protected enum Property { POSITION, ROTATION, SCALE }
    [SerializeField]
    protected Property property;

    [HideInInspector]
    public float currentTime;
    [SerializeField]
    protected Vector3 initialValue;
    [SerializeField]
    protected Vector3 finalValue;
    public float durationTime;

    [SerializeField]
    protected float delayStart;
    [SerializeField]
    protected bool randomDelay;
    [SerializeField]
    protected float minDelay;
    [SerializeField]
    protected float maxDelay; 

    protected Vector3 deltaValue;
    protected Vector3 easingValue; 

    public bool animLoop;
    protected bool invertValues;

    public bool isPaused;

    protected virtual void DoEasing()
    {
    }
}
