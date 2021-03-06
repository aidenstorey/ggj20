using System;
using UnityEngine;

public class state
{
    public bool completed = false;

    public virtual void update()
    {
        this.completed = true;
    }
}

public class pause : state
{
    float _duration;
    float _current;

    public pause(float duration)
    {
        this._duration = duration;
    }

    public override void update()
    {
        this._current = Mathf.Min(this._duration, this._current + Time.deltaTime);

        if (this._current >= this._duration)
        {
            this.completed = true;
        }
    }
}

public class tween : state
{
    GameObject _go;
    Vector3 _start;
    Vector3 _delta;
    float _duration;
    float _current = 0.0f;

    public tween(GameObject go, Vector3 start, Vector3 end, float duration)
    {
        this._go = go;
        this._start = start;
        this._delta = end - this._start;
        this._duration = duration;
    }

    public override void update()
    {
        this._current = Mathf.Min(this._duration, this._current + Time.deltaTime);

        this._go.transform.position = this._start + this._delta / this._duration * this._current;

        if (this._current >= this._duration)
        {
            this.completed = true;
        }
    }
}

public class close_game : state
{
    public override void update()
    {
        Application.Quit();
        this.completed = true;
    }
}

public class one_shot: state
{
    Action _action;

    public one_shot(Action action)
    {
        this._action = action;
    }

    public override void update()
    {
        this._action();
        this.completed = true;
    }
}
