using UnityEngine;

public class test_controller : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
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
}
