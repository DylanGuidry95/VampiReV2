using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Assets.Scripts.Brett.NpcBehaviour))]
public class DetectionScirtVisual : MonoBehaviour {
	public Assets.Scripts.Brett.NpcBehaviour BehaviourRef;
	List<Vector3> Verts;
	List<int> TriPoints;
	List<Vector3> SurfaceNormals;
	List<Vector3> UVs;

	public Mesh InstanceMesh;
	public MeshFilter InstanceMeshFilter;
	public Material InstaceMaterial;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		BehaviourRef = GetComponent<Assets.Scripts.Brett.NpcBehaviour>();
		Verts = new List<Vector3>();
		TriPoints = new List<int>();
		SurfaceNormals = new List<Vector3>();
		UVs = new List<Vector3>();
	}

	void GenerateRuntimeSkirt()
	{
		GenerateConeOfView();
		InstanceMesh.vertices = Verts.ToArray();

		for(int i = 1; i < Verts.Count; i+=3)
		{
			
		}
	}

	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{				
		GenerateConeOfView();
		Gizmos.color = Color.yellow;
		foreach (var vec in Verts)
		{
			Gizmos.DrawLine(transform.position, vec);
		}
	}

	void GenerateConeOfView()
	{
		Verts = new List<Vector3>();
		if(BehaviourRef == null)
			BehaviourRef = GetComponent<Assets.Scripts.Brett.NpcBehaviour>();
		var angle = BehaviourRef.AngleOfView;
		var Distance = BehaviourRef.DistanceOfView;

        List<Ray> rays = new List<Ray>();
        for (float i = -angle; i < angle; i += 3f)
        {
            Quaternion spread = Quaternion.AngleAxis(i, transform.up);
            Vector3 newVec = spread * transform.forward;
            rays.Add(new Ray(transform.position, newVec));
        }
		Verts.Add(transform.position);
        foreach (var r in rays)
        {
			RaycastHit hit;
			if(Physics.Raycast(r.origin, r.direction, out hit, Distance))			
			{	
				Verts.Add(hit.point);
			}
			else
	        {
				Verts.Add(r.origin + (r.direction * Distance));
			}
        }		
	}
}
