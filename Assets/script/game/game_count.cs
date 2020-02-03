using UnityEngine;
using UnityEngine.UI;

public class game_count : MonoBehaviour
{
    public Text countdown;

    void Update()
    {
        countdown.text = dino_spawn_controller.instance.current_count + "/" + dino_spawn_controller.instance.spawn_count;
    }
}
