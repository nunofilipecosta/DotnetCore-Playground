using System;

namespace PatternsAndPractices.Command
{
    public interface ICommand
    {
        public void Execute();

        public bool CanExecute();

        public void Undo();
    }
}
