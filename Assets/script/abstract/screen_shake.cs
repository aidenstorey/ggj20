using UnityEngine;

public class screen_shake : state
{
    float _duration = 0.0f;
    float _intensity = 0.0f;

    public screen_shake(float duration, float intensity)
    {
        this._duration = duration;
        this._intensity = intensity;
    }

    public override void update()
    {
        Camera.main.GetComponent<camera>().screen_shake(_duration, _intensity);
        this.completed = true;
    }
}
