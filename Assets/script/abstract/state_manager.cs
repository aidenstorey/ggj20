using System.Collections.Generic;

public class state_manager
{
    static state _current;
    static Queue<state> _state_queue = new Queue<state>();

    static void _update_current()
    {
        if ((_current != null && _current.completed) || _current == null)
        {
            if (_state_queue.Count > 0)
            {
                _current = _state_queue.Dequeue();
            }
            else
            {
                _current = null;
            }
        }
    }

    static public void add_queue(params state[] s)
    {
        foreach (var i in s)
        {
            _state_queue.Enqueue(i);
        }

        state_manager._update_current();
    }

    static public void clear_queue()
    {
        _state_queue.Clear();
    }

    static public void update()
    {
        if (_current != null)
        {
            _current.update();

            state_manager._update_current();
        }
    }
}
