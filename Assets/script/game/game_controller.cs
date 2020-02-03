using UnityEngine;

public class game_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var meteor = GameObject.FindGameObjectWithTag("meteor");
        var state_controller = meteor.transform.parent.gameObject.GetComponent<meteor_state_controller>();

        state_manager.add_queue(
            new spawn_dinos(),
            new tween(meteor, meteor.transform.position, new Vector3(0.0f, 3.0f), 0.5f),
            new one_shot(() => state_controller.state = meteor_state.idle),
            new one_shot(() => game_timer.instance.start_timer())
        );
    }

    // Update is called once per frame
    void Update()
    {
        state_manager.update();
        this.control_meteors();
    }

    void control_meteors()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            foreach(var meteor_controller in FindObjectsOfType<meteor_state_controller>())
            {
                meteor_controller.state = meteor_state.move;
                meteor_controller.direction = meteor_direction.left;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            foreach(var meteor_controller in FindObjectsOfType<meteor_state_controller>())
            {
                meteor_controller.state = meteor_state.move;
                meteor_controller.direction = meteor_direction.right;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var meteor_controller in FindObjectsOfType<meteor_state_controller>())
            {
                meteor_controller.state = meteor_state.drop;
            }
        }
    }
}
