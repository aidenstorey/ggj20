using UnityEngine;
using UnityEditor.Animations;


public class dino_animation_controller : MonoBehaviour
{
    public AnimatorController[] controllers;
    Animator _animator;

    void Start()
    {
        this._animator = this.GetComponent<Animator>();
        this._animator.runtimeAnimatorController = this.controllers[Random.Range(0, controllers.Length)];
    }

    public void change_facing_direction(dino_facing_direction facing_direction)
    {
        var scale = this.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (dino_facing_direction.left == facing_direction ? -1.0f: 1.0f);

        this.transform.localScale = scale;
    }

    public void change_state(dino_state state)
    {
        this._animator.Play(state.ToString());
    }
}
