using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dino_movement_controller : MonoBehaviour
{

    Dictionary<dino_facing_direction, Vector3> dino_movement_offset = new Dictionary<dino_facing_direction, Vector3>()
    {
        { dino_facing_direction.left, new Vector3(-1.0f, 0.0f) },
        { dino_facing_direction.right, new Vector3(1.0f, 0.0f) },
    };

    Dictionary<dino_state, float> dino_speed_modifier = new Dictionary<dino_state, float>()
    {
        { dino_state.idle, 0.0f },
        { dino_state.walk, 0.05f },
        { dino_state.run, 0.1f },
        { dino_state.hurt, 0.0f },
    };

    Vector3 _movement_offset;
    float _speed_modifier;

    public float speed = 1.0f;


    void Update()
    {
        this.process_movement();
    }

    void process_movement()
    {
        this.transform.position += this._movement_offset * (this._speed_modifier * this.speed);
    }

    public void change_facing_direction(dino_facing_direction facing_direction)
    {
        this._movement_offset = this.dino_movement_offset[facing_direction];
    }

    public void change_state(dino_state state)
    {
        this._speed_modifier = this.dino_speed_modifier[state];
    }
}
