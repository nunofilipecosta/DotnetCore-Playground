using System.Collections.Generic;

namespace PatternsAndPractices.Command
{
    public class CommandManager
    {
        private Stack<ICommand> commands = new Stack<ICommand>();

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                commands.Push(command);
                command.Execute();
            }
        }

        public void Undo()
        {
            while (commands.Count > 0)
            {
                var currentCommand = commands.Pop();
                currentCommand.Undo();
            }
        }
    }
}
