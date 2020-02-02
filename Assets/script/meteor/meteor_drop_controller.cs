using UnityEngine;
using System.Collections;

public class meteor_drop_controller : MonoBehaviour
{
    GameObject _meteor_object;

    void Start()
    {
        this._meteor_object = this.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        state_manager.update();
    }

    public void change_state(meteor_state state)
    {
        if(state == meteor_state.drop)
        {
            var position_a = this._meteor_object.transform.position;
            var position_b = position_a + new Vector3(0.0f, -7.20f);
            var position_c = position_b + new Vector3(0.0f, 1.0f);
            var position_d = position_c + new Vector3(0.0f, -3.5f);
            var position_e = position_a + new Vector3(0.0f, 2.0f);

            state_manager.add_queue(
                new tween(this._meteor_object, position_a, position_b, 0.5f),
                new tween(this._meteor_object, position_b, position_c, 0.15f),
                new tween(this._meteor_object, position_c, position_d, 0.4f),
                new tween(this._meteor_object, position_e, position_a, 0.5f));
        }
    }
}
