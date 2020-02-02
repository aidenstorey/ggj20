using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_controller : MonoBehaviour
{

    void Start()
    {
        this.add_ai();
        this.randomize_dinos_speed();
    }

    // Update is called once per frame
    void Update()
    {
        // this.change_animation();
        // this.control_dinos();
        this.control_meteors();
    }

    void add_ai()
    {
        foreach(var dino_controller in FindObjectsOfType<dino_state_controller>())
        {
            dino_controller.gameObject.AddComponent<dino_ai_controller>();
            dino_controller.facing_direction = (int)Mathf.Round(Random.value) == 0 ? dino_facing_direction.left : dino_facing_direction.right;
        }
    }

    void control_dinos()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach(var dino_controller in FindObjectsOfType<dino_state_controller>())
            {
                dino_controller.facing_direction = dino_facing_direction.left;
                dino_controller.state = dino_state.run;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            foreach(var dino_controller in FindObjectsOfType<dino_state_controller>())
            {
                dino_controller.state = dino_state.idle;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach(var dino_controller in FindObjectsOfType<dino_state_controller>())
            {
                dino_controller.facing_direction = dino_facing_direction.right;
                dino_controller.state = dino_state.walk;
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            foreach(var dino_controller in FindObjectsOfType<dino_state_controller>())
            {
                dino_controller.state = dino_state.idle;
            }
        }
    }

    void control_meteors()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach(var meteor_controller in FindObjectsOfType<meteor_state_controller>())
            {
                meteor_controller.state = meteor_state.move;
                meteor_controller.direction = meteor_direction.left;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach(var meteor_controller in FindObjectsOfType<meteor_state_controller>())
            {
                meteor_controller.state = meteor_state.move;
                meteor_controller.direction = meteor_direction.right;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            foreach(var meteor_controller in FindObjectsOfType<meteor_state_controller>())
            {
                meteor_controller.state = meteor_state.idle;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            foreach(var meteor_controller in FindObjectsOfType<meteor_state_controller>())
            {
                meteor_controller.state = meteor_state.drop;
            }
        }
    }

    void change_animation()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach(var dino_controller in FindObjectsOfType<dino_animation_controller>())
            {
                dino_controller.change_state(dino_state.idle);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach(var dino_controller in FindObjectsOfType<dino_animation_controller>())
            {
                dino_controller.change_state(dino_state.walk);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach(var dino_controller in FindObjectsOfType<dino_animation_controller>())
            {
                dino_controller.change_state(dino_state.run);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach(var dino_controller in FindObjectsOfType<dino_animation_controller>())
            {
                dino_controller.change_state(dino_state.hurt);
            }
        }
    }

    void randomize_dinos_speed()
    {
        foreach(var dino_controller in FindObjectsOfType<dino_movement_controller>())
        {
            dino_controller.speed = Random.value + 0.5f;
        }
    }
}
