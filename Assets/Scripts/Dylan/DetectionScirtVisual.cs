using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScirtVisual : MonoBehaviour {
	public Assets.Scripts.Brett.GuestNPCBehaviour BehaviourRef;
	public List<Vector3> Verts;
	List<int> TriPoints;
	List<Vector3> SurfaceNormals;
	List<Vector2> UVs;

	public Mesh InstanceMesh;
	public MeshFilter InstanceMeshFilter;
	public Material InstaceMaterial;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		BehaviourRef = GetComponentInParent<Assets.Scripts.Brett.GuestNPCBehaviour>();
		Verts = new List<Vector3>();
		TriPoints = new List<int>();
		SurfaceNormals = new List<Vector3>();
		UVs = new List<Vector2>();
		InstanceMesh = new Mesh();		
		GenerateRuntimeSkirt();
	}

	[ContextMenu("Test")]
	void GenerateRuntimeSkirt()
	{		
		GenerateConeOfView();
		InstanceMesh = new Mesh();
		InstanceMesh.vertices = Verts.ToArray();

		for(int i = Verts.Count - 1; i > 1; i--)
		{
			TriPoints.Add(i);
			TriPoints.Add(0);
			TriPoints.Add(i - 1);						
		}
		InstanceMesh.triangles = TriPoints.ToArray();		

		foreach(var vert in Verts)
        {
			SurfaceNormals.Add(new Vector3(0,1,0));
            UVs.Add(new Vector2(vert.x, vert.y));
        }

		InstanceMesh.normals = SurfaceNormals.ToArray();

		InstanceMesh.uv = UVs.ToArray();

		InstanceMeshFilter.mesh = InstanceMesh;
	}

	private void Update() 
	{
		GenerateConeOfView();
		var vert = InstanceMesh.vertices;
		foreach (var v in Verts)
		{
			vert[Verts.IndexOf(v)] = v - transform.position;
		}	
		InstanceMesh.vertices = vert;
	}

	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{				
		//GenerateConeOfView();
		//Gizmos.color = Color.yellow;
		//foreach (var vec in Verts)
		//{
		//	Gizmos.DrawLine(transform.position, vec);
		//	Gizmos.DrawCube(vec, new Vector3(.25f,.25f,.25f));
		//}
	}

	void GenerateConeOfView()
	{
		Verts = new List<Vector3>();
		if(BehaviourRef == null)
			BehaviourRef = GetComponentInParent<Assets.Scripts.Brett.GuestNPCBehaviour>();
		var angle = BehaviourRef.AngleOfView;
		var Distance = BehaviourRef.DistanceOfView;

        List<Ray> rays = new List<Ray>();
        for (float i = -angle; i < angle; i += 1f)
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
