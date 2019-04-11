using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Dylan;
using UnityEngine;

public class FeedingGrabbableBehaviour : GrabbableBehaviour
{
    private Material BaseMaterial;

    public bool isGrabbed;

	
    public override void Grabbed(Transform grabber)
    {
        isGrabbed = true;
    }

    public override void LetGo(Vector3 travelVelocity)
    {
        isGrabbed = false;
    }

    public void HighLight(bool isHighlighted)
    {
        GetComponent<MeshRenderer>().material = (isHighlighted) ? HighLightMaterial : BaseMaterial;
    }
}
