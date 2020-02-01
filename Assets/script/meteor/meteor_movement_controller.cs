using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor_movement_controller : MonoBehaviour
{
    Dictionary<meteor_direction, Vector3> meteor_movement_offset = new Dictionary<meteor_direction, Vector3>()
    {
        { meteor_direction.left, new Vector3(-1.0f, 0.0f) },
        { meteor_direction.right, new Vector3(1.0f, 0.0f) },
    };

    Dictionary<meteor_state, float> meteor_speed_modifier = new Dictionary<meteor_state, float>()
    {
        { meteor_state.idle, 0.0f },
        { meteor_state.move, 0.05f },
        { meteor_state.drop, 0.0f },
    };

    Vector3 _movement_offset = Vector3.zero;
    float _speed_modifier = 0.0f;

    public float speed = 1.0f;


    void Update()
    {
        this.process_movement();
    }

    void process_movement()
    {
        var offset = this._movement_offset * (this._speed_modifier * this.speed);
        this.transform.position = game_border_controller.instance.keep_in_bounds(this.transform.position + offset);
    }

    public void change_direction(meteor_direction direction)
    {
        this._movement_offset = this.meteor_movement_offset[direction];
    }

    public void change_state(meteor_state state)
    {
        this._speed_modifier = this.meteor_speed_modifier[state];
    }
}
