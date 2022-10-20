using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CubeSpawner : MonoBehaviour
{
	public Transform	Prefab = null;
	public float		Distance = 1;
	public float		Velocity = 1;
	public float		SpawnPeriod = 1;
	public bool			isRun = false;

	float				Timer = 0;
	bool				isInit = false;



	void Awake()
	{
		if (Prefab == null || Distance < 0.001f || Velocity < 0.001f)
			return;

		isInit = true;
	}



	void Start()
	{
	}
	


	void Update()
	{
		Transform	NewCube;
		Cube		CubeScript;

		if (!isInit || !isRun)
			return;

		Timer += Time.deltaTime;
		if (Timer >= SpawnPeriod)
		{
			Timer -= SpawnPeriod;
			NewCube = Instantiate(Prefab, transform.position, transform.rotation);

			CubeScript = NewCube.GetComponent<Cube>();
			if (CubeScript != null)
				CubeScript.Init(transform.position, transform.rotation, Distance, Velocity);
			else
				Destroy(NewCube);
		}
	}
}
