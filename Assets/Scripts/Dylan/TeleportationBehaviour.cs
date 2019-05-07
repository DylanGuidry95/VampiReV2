using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TeleportationBehaviour : MonoBehaviour 
{
	private LineRenderer TeleportationLine;
	
	public float MaxTeleportDistance;	

	GameObject TeleportDestination;

	Assets.Scripts.Brett.GameEvent TeleportEvent;
	

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		TeleportationLine = GetComponent<LineRenderer>();
		MaxTeleportDistance = MaxTeleportDistance < 0 ? 1 : MaxTeleportDistance;
	}

	public void StartTeleport() 
	{
		TeleportationLine.SetPosition(0, transform.position);
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, MaxTeleportDistance))
		{
			if(hit.transform.GetComponent<HTC.UnityPlugin.Vive.Teleportable>())
			{
				if(TeleportDestination == null)
				{
					TeleportDestination = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					Destroy(TeleportDestination.GetComponent<Collider>());
				}
				TeleportDestination.transform.position = hit.point;
				TeleportationLine.enabled = true;
				TeleportationLine.SetPosition(1, hit.point);
			}
			else if(TeleportDestination != null)
			{
			TeleportationLine.enabled = false;
			Destroy(TeleportDestination);			
			}
		}
		else
		{	
			TeleportationLine.enabled = false;
			TeleportationLine.SetPosition(1, transform.position);
		}
	}

	public void Teleport(GameObject teleportObject)
	{
		if(TeleportDestination != null)
		{
			teleportObject.transform.position = TeleportDestination.transform.position;
			TeleportationLine.enabled = false;
			Destroy(TeleportDestination);	
			//TeleportEvent.Raise();
		}
	}
}
