using UnityEngine;

public class meteor_drop_controller : MonoBehaviour
{
    GameObject _meteor_object;
    meteor_state_controller _state_controller;

    void Start()
    {
        this._meteor_object = this.transform.GetChild(0).gameObject;
        this._state_controller = this.GetComponent<meteor_state_controller>();
    }

    private void Update()
    {
        state_manager.update();
    }

    public void change_state(meteor_state state)
    {
        if(state == meteor_state.drop && !state_manager.processing)
        {
            var position_a = this._meteor_object.transform.position;
            var position_b = position_a + new Vector3(0.0f, -7.60f);
            var position_c = position_b + new Vector3(0.0f, 1.0f);
            var position_d = position_c + new Vector3(0.0f, -3.5f);
            var position_e = position_a + new Vector3(0.0f, 2.0f);

            state_manager.add_queue(
                new tween(this._meteor_object, position_a, position_b, 0.5f),
                new screen_shake(0.5f, 0.3f),
                new dino_hit(position_b),
                new tween(this._meteor_object, position_b, position_c, 0.1f),
                new tween(this._meteor_object, position_c, position_d, 0.35f),
                new tween(this._meteor_object, position_e, position_a, 0.6f),
                new one_shot(() => this._state_controller.state = meteor_state.idle)
            );

        }
    }
}
