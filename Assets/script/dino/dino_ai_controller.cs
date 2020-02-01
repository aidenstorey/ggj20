using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class dino_ai_controller : MonoBehaviour
{
    dino_state_controller _state_controller;

    void Start()
    {
        this._state_controller = this.GetComponent<dino_state_controller>();
        this._state_controller.state = dino_state.walk;
    }

    // Update is called once per frame
    void Update()
    {
        this.dumb_ai();
    }

    void dumb_ai()
    {
        if ((int)(Random.value * 100.0f) == 0)
        {
            this._state_controller.facing_direction = helper.iterate_enum_excluding(this._state_controller.facing_direction).First();;
        }
    }
}
