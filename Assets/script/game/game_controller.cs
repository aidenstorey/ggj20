using UnityEngine;

public class game_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var meteor = GameObject.FindGameObjectWithTag("meteor");

        state_manager.add_queue(
            new spawn_dinos(),
            new tween(meteor, meteor.transform.position, new Vector3(0.0f, 3.0f), 0.2f)
        );
    }
}
