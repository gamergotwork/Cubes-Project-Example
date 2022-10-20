using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cube : MonoBehaviour
{
	Vector3		StartPosition;
	Quaternion	StartRotation;
	float		Dlimit;
	float		Dcurrent;
	float		Vcurrent;
	bool		isInit;



	public bool Init(Vector3 Position, Quaternion Rotation, float Distance, float Velocity)
	{
		StartPosition = Position;
		StartRotation = Rotation;
		Dlimit = Distance;
		Dcurrent = 0;
		Vcurrent = Velocity;

		transform.position = StartPosition;
		transform.rotation = StartRotation;

		isInit = true;
		return true;
	}



	void Update()
	{
		if (!isInit)
		{
			Destroy(transform.gameObject);
			return;
		}

		Dcurrent += Vcurrent * Time.deltaTime;
		transform.position = StartPosition + StartRotation * Vector3.forward * Dcurrent;

		if (Dcurrent > Dlimit)
			Destroy(transform.gameObject);
	}
}
