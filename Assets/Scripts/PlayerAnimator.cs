using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour, IAnimator
{
	[SerializeField]
	private Animator _animator;

	private Dictionary<AnimationType, int> _animations = new Dictionary<AnimationType, int>()
	{
		{AnimationType.Idle, Animator.StringToHash("IsIdle")},
		{AnimationType.Run, Animator.StringToHash("IsRun")},
		{AnimationType.Aim, Animator.StringToHash("IsAim")},
		{AnimationType.Shoot, Animator.StringToHash("IsShoot")},
	};

	public void SetParameterInt(AnimationType type, int value)
	{
		if (!_animations.ContainsKey(type))
		{
			Debug.LogError($"Animation {type} is not contains in animation dictionary!");
		}

		if (_animator.GetInteger(_animations[type]) == value)
		{
			return;
		}

		_animator.SetInteger(_animations[type], value);
	}

	public void SetParameterFloat(AnimationType type, float value)
	{
		if (!_animations.ContainsKey(type))
		{
			Debug.LogError($"Animation {type} is not contains in animation dictionary!");
		}

		if (_animator.GetFloat(_animations[type]) == value)
		{
			return;
		}

		_animator.SetFloat(_animations[type], value);
	}

	public void SetParameterBool(AnimationType type, bool value)
	{
		if (!_animations.ContainsKey(type))
		{
			Debug.LogError($"Animation {type} is not contains in animation dictionary!");
		}

		if (_animator.GetBool(_animations[type]) == value)
		{
			return;
		}

		_animator.SetBool(_animations[type], value);
	}

	public void SetParameterTrigger(AnimationType type, bool value)
	{
		if (!_animations.ContainsKey(type))
		{
			Debug.LogError($"Animation {type} is not contains in animation dictionary!");
		}

		if (value)
		{
			_animator.SetTrigger(_animations[type]);
		}
		else
		{
			_animator.ResetTrigger(_animations[type]);
		}
	}
}
