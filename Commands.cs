using System;
using System.Collections.Generic;

namespace Lab2_CommandTextEditor
{
    // Интерфейс команды
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Команда Copy
    public class CopyCommand : ICommand
    {
        private TextEditor _editor;
        private int _from, _to;
        private string _previousClipboard;

        public CopyCommand(TextEditor editor, int from, int to)
        {
            _editor = editor;
            _from = from;
            _to = to;
        }

        public void Execute()
        {
            _previousClipboard = _editor.Clipboard;
            _editor.Copy(_from, _to);
        }

        public void Undo()
        {
            _editor.Clipboard = _previousClipboard;
        }
    }

    // Команда Paste
    public class PasteCommand : ICommand
    {
        private TextEditor _editor;
        private int _position;
        private string _previousText;

        public PasteCommand(TextEditor editor, int position)
        {
            _editor = editor;
            _position = position;
        }

        public void Execute()
        {
            _previousText = _editor.Text;
            _editor.Paste(_position);
        }

        public void Undo()
        {
            _editor.Text = _previousText;
        }
    }

    // Команда Insert
    public class InsertCommand : ICommand
    {
        private TextEditor _editor;
        private int _position;
        private string _string;
        private string _previousText;

        public InsertCommand(TextEditor editor, int position, string str)
        {
            _editor = editor;
            _position = position;
            _string = str;
        }

        public void Execute()
        {
            _previousText = _editor.Text;
            _editor.Insert(_position, _string);
        }

        public void Undo()
        {
            _editor.Text = _previousText;
        }
    }

    // Команда Delete
    public class DeleteCommand : ICommand
    {
        private TextEditor _editor;
        private int _from, _to;
        private string _deletedText;
        private string _previousText;

        public DeleteCommand(TextEditor editor, int from, int to)
        {
            _editor = editor;
            _from = from;
            _to = to;
        }

        public void Execute()
        {
            _previousText = _editor.Text;
            if (_from < 0) _from = 0;
            if (_to > _previousText.Length) _to = _previousText.Length;
            if (_from >= _to) return;
            _deletedText = _previousText.Substring(_from, _to - _from);
            _editor.Delete(_from, _to);
        }

        public void Undo()
        {
            _editor.Text = _previousText;
        }
    }

    // Invoker (хранит историю для undo/redo)
    public class CommandInvoker
    {
        private Stack<ICommand> _undoStack = new Stack<ICommand>();
        private Stack<ICommand> _redoStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count == 0) return;
            ICommand cmd = _undoStack.Pop();
            cmd.Undo();
            _redoStack.Push(cmd);
        }

        public void Redo()
        {
            if (_redoStack.Count == 0) return;
            ICommand cmd = _redoStack.Pop();
            cmd.Execute();
            _undoStack.Push(cmd);
        }
    }
}