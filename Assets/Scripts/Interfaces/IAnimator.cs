
public interface IAnimator
{
	void SetParameterInt(AnimationType type, int value);
	void SetParameterFloat(AnimationType type, float value);
	void SetParameterBool(AnimationType type, bool value);
	void SetParameterTrigger(AnimationType type, bool value);
}
