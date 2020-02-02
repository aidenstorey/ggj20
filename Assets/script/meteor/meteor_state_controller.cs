using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum meteor_direction { left, right };
public enum meteor_state { idle, move, drop };

public class meteor_state_controller : MonoBehaviour
{
    meteor_movement_controller _movement_controller;
    meteor_drop_controller _drop_controller;

    meteor_direction _direction = meteor_direction.right;
    meteor_state _state = meteor_state.idle;

    void Start()
    {
        this._movement_controller = this.GetComponent<meteor_movement_controller>();
        this._movement_controller.change_state(this._state);

        this._drop_controller = this.GetComponent<meteor_drop_controller>();
        this._drop_controller.change_state(this._state);
    }

    public meteor_state state
    {
        get
        {
            return this._state;
        }

        set
        {
            if (value != this._state)
            {
                if (this._state == meteor_state.drop && value == meteor_state.move)
                {
                    return;
                }

                this._state = value;

                this._movement_controller.change_state(this._state);
                this._drop_controller.change_state(this._state);
            }
        }
    }

    public meteor_direction direction {
        get
        {
            return this._direction;
        }

        set
        {
            if (value != this._direction)
            {
                this._direction = value;

                this._movement_controller.change_direction(this._direction);
            }
        }
    }
}
