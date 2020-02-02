using UnityEngine;

public enum dino_facing_direction { left, right };
public enum dino_state { idle, walk, run, hurt };

public class dino_state_controller : MonoBehaviour
{
    dino_animation_controller _animation_controller;
    dino_hurt_controller _hurt_controller;
    dino_movement_controller _movement_controller;

    dino_facing_direction _facing_direction = dino_facing_direction.right;
    dino_state _state = dino_state.idle;

    void Start()
    {
        this._animation_controller = this.GetComponent<dino_animation_controller>();
        this._animation_controller.change_state(this._state);

        this._hurt_controller = this.GetComponent<dino_hurt_controller>();
        this._hurt_controller.change_state(this.state);

        this._movement_controller = this.GetComponent<dino_movement_controller>();
        this._movement_controller.change_state(this._state);
    }

    public dino_state state
    {
        get
        {
            return this._state;
        }

        set
        {
            if (value != this._state)
            {
                this._state = value;

                this._animation_controller.change_state(this._state);
                this._hurt_controller.change_state(this._state);
                this._movement_controller.change_state(this._state);
            }
        }
    }

    public dino_facing_direction facing_direction {
        get
        {
            return this._facing_direction;
        }

        set
        {
            if (value != this._facing_direction)
            {
                this._facing_direction = value;

                this._animation_controller.change_facing_direction(this._facing_direction);
                this._movement_controller.change_facing_direction(this._facing_direction);
            }
        }
    }
}
