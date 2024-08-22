using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class MoveCommand : ICommand
    {
        private Transform _transform;
        private Vector3 _direction;

        public MoveCommand(Transform transform, Vector3 direction)
        {
            _transform = transform;
            _direction = direction;
        }
        
        public void Execute()
        {
            _transform.localPosition += _direction;
        }

        public void Undo()
        {
            _transform.localPosition -= _direction;
        }
    }

    //移动目标
    public Transform _target;
    private Stack<ICommand> _commands = new Stack<ICommand>();
    private Stack<ICommand> _redocommands = new Stack<ICommand>();

    public void OnUndoClick()
    {
        if (_commands.Count <= 0)
        {
            Debug.LogWarning("no commands");
            return;
        }
        ICommand command = _commands.Pop();
        command.Undo();
        _redocommands.Push(command);
    }
    
    public void OnRedoClick()
    {
        if (_redocommands.Count <= 0)
        {
            Debug.LogWarning("no redo commands");
            return;
        }
        ICommand command = _redocommands.Pop();
        command.Execute();
        _commands.Push(command);
    }
    
    public void OnMoveLeftClick()
    {
        ICommand command = new MoveCommand(_target, new Vector3(-100, 0, 0));
        command.Execute();
        _commands.Push(command);
    }
    
    public void OnMoveRightClick()
    {
        ICommand command = new MoveCommand(_target, new Vector3(100, 0, 0));
        command.Execute();
        _commands.Push(command);
    }
}
