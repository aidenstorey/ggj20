using UnityEngine;

public class game_border_controller
{
    private static game_border_controller _instance;

    float boarder_left, boarder_right;


    private game_border_controller()
    {
        var left = GameObject.FindGameObjectsWithTag("dino_edge_left");
        if (left.Length != 0)
        {
            this.boarder_left = left[0].transform.position.x;
        }

        var right = GameObject.FindGameObjectsWithTag("dino_edge_right");
        if (right.Length != 0)
        {
            this.boarder_right = right[0].transform.position.x;
        }
    }

    public static game_border_controller instance
    {
        get
        {
            if (game_border_controller._instance == null)
            {
                game_border_controller._instance = new game_border_controller();

            }

            return game_border_controller._instance;
        }
    }

    public Vector3 keep_in_bounds(Vector3 position)
    {
        position.x = Mathf.Max(this.boarder_left, Mathf.Min(this.boarder_right, position.x));
        return position;
    }
}
