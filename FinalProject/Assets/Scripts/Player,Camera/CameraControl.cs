using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float panSpeed = 20f;
	public float panBorderThickness = 10f;
	public Vector2 panLimit;
	public float scrollSpeed = 20f;
	public float minY = 20f;
	public float maxY = 120f;

	void Update () 
	{
		Vector3 camPos = transform.position;

		if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness )
		{
			camPos.z += panSpeed * Time.deltaTime;
		}
			if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness )
		{
			camPos.z -= panSpeed * Time.deltaTime;
		}
			if(Input.GetKey("d") || Input.mousePosition.y >= Screen.width - panBorderThickness )
		{
			camPos.x += panSpeed * Time.deltaTime;
		}
			if(Input.GetKey("a") || Input.mousePosition.y <= panBorderThickness )
		{
			camPos.x -= panSpeed * Time.deltaTime;
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		camPos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;
		camPos.x = Mathf.Clamp(camPos.x, -panLimit.x, panLimit.x);
		camPos.y = Mathf.Clamp(camPos.y, minY,	maxY);
		camPos.y = Mathf.Clamp(camPos.y, -panLimit.y, panLimit.y);

		transform.position = camPos;
	}
}
