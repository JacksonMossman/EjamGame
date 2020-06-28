using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control_marks : MonoBehaviour
{
	public GameObject cam_obj;
	public Quaternion cam_obj_original_rot;
	public Quaternion player_obj_original_rot;

	public float sensitivityX = 15f;
	public float sensitivityY = 15f;

	public float minimumX = -360f;
	public float maximumX = 360f;

	public float minimumY = -60f;
	public float maximumY = 60f;

	float rotationX = 0F;
	float rotationY = 0F;

	void Start()
	{
		cam_obj = this.gameObject.transform.GetChild(0).gameObject;
		cam_obj_original_rot = cam_obj.transform.localRotation;
		player_obj_original_rot = this.transform.rotation;
	}

	void Update()
	{
		rotationX += Input.GetAxis("Mouse X") * sensitivityX;
		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

		rotationX = ClampAngle(rotationX, minimumX, maximumX);
		rotationY = ClampAngle(rotationY, minimumY, maximumY);

		Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

		cam_obj.transform.localRotation = cam_obj_original_rot * yQuaternion;
		this.transform.localRotation = player_obj_original_rot * xQuaternion;
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
}
