using UnityEngine;

public class dino_hurt_controller : MonoBehaviour
{
    bool _dying = false;

    void Update()
    {
        if (this._dying)
        {
            this.transform.position -= new Vector3(0.0f, Time.deltaTime * 5.0f);
            if (this.transform.position.y < -10)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void change_state(dino_state state)
    {
        if (state == dino_state.hurt)
        {
            this._dying = true;
        }
    }
}
