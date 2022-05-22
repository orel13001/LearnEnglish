using System;


namespace LearnEnglish.WPF.Infrastructure.Command.Base
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Excecute;
        private readonly Func<object, bool> _CanExecute;


        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null!)
        {
            _Excecute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Excecute(parameter);
    }
}
