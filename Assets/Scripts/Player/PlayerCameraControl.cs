using UnityEngine;

public class PlayerCameraControl : MonoBehaviour, CameraControl
{
	[SerializeField]
	private Vector3 _cameraOffset;

	private Vector3 _targetPosition;
	private Transform _target;
	
	private void Awake()
	{
		StaticContainer.Add(typeof(CameraControl), this);
	}

	public void SetTarget(Transform target)
	{
		_target = target;
		_targetPosition = target.position;
		_targetPosition.x = transform.position.x;
	}

	public void UpdatePosition()
	{
		_targetPosition.z = _target.position.z;
		_targetPosition.y = _target.position.y;
		transform.position = _targetPosition + _cameraOffset;
	}
}
