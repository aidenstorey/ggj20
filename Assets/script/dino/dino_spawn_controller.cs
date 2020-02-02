using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class dino_spawn_controller : MonoBehaviour
{
    static dino_spawn_controller _instance;

    public GameObject dino;
    public int spawn_count = 50;
    public float spawn_time = 2.0f;

    List<GameObject> _dinos;

    bool _spawning = true;
    float _frequency = 0.0f;
    float _next = 0.0f;

    Vector3 _spawn_left;
    Vector3 _spawn_right;

    void Start()
    {
        if(dino_spawn_controller._instance != null)
        {
            Destroy(this);
            return;
        }

        dino_spawn_controller._instance = this;

        this._dinos = new List<GameObject>();
        this._frequency = (this.spawn_time / this.spawn_count) * 0.9f;

        this._spawn_left = GameObject.FindGameObjectWithTag("dino_edge_left").transform.position;
        this._spawn_right = GameObject.FindGameObjectWithTag("dino_edge_right").transform.position;
    }

    void Update()
    {
        if (this._spawning && this.spawn_count != 0)
        {
            this._next = Mathf.Max(0.0f, this._next - Time.deltaTime);
            if (this._next == 0.0f)
            {
                var spawn_position = (int)Mathf.Round(Random.value) == 0.0f ? this._spawn_left : this._spawn_right;

                var go = Instantiate(this.dino, spawn_position, Quaternion.identity);
                go.transform.parent = this.transform;
                this._dinos.Add(go);

                this._next = this._frequency;
            }

            this._spawning = this._dinos.Count != this.spawn_count;
        }
    }

    static public dino_spawn_controller instance {
        get { return dino_spawn_controller._instance; }
    }

    public void spawn()
    {
        this._spawning = true;
    }

    public void kill_near(Vector3 position, float distance)
    {
        var count = 0;

        this._dinos = this._dinos.OrderBy(dino => {
            var delta = (position - dino.transform.position).magnitude;

            if (delta < distance)
            {
                count++;
            }

            return delta;
        }).ToList();

        for (int i = 0; i < count; i++)
        {
            this._dinos[i].GetComponent<dino_state_controller>().state = dino_state.hurt;
        }

        this._dinos.RemoveRange(0, count);
    }
}
