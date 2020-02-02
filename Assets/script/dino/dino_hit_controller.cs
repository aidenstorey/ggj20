using UnityEngine;

public class dino_hit_controller : MonoBehaviour
{
    static dino_hit_controller _instance;

    Vector3 _origin;
    float _bounce_time = 0.0f;

    void Start()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        dino_hit_controller._instance = this;
        this._origin = this.transform.position;
    }

    void Update()
    {
        if (this._bounce_time > 0.0f)
        {
            this._bounce_time = Mathf.Max(0.0f, this._bounce_time - Time.deltaTime);

            this.transform.position = this._origin + new Vector3(0.0f, Mathf.Sin((1.0f / 0.2f) * this._bounce_time));

            if (this._bounce_time == 0.0f)
            {
                this.transform.position = this._origin;
            }
        }
    }

    static public void hit(Vector3 position)
    {
        if (dino_hit_controller._instance._bounce_time == 0.0f)
        {
            dino_hit_controller._instance._bounce_time = 0.2f;
        }
    }
}

public class dino_hit : state
{
    Vector3 _position;

    public dino_hit(Vector3 position)
    {
        this._position = position;
    }

    public override void update()
    {
        dino_hit_controller.hit(this._position);
        this.completed = true;
    }
}
