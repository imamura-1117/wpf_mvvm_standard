using System.Windows.Input;

namespace WPFMVVMStandard.Command
{
    /// <summary>
    /// コマンド基底クラス
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// コマンドの実態
        /// </summary>
        private Action<object?>? _execute;

        /// <summary>
        /// コマンドの実行可否判定の処理
        /// </summary>
        private Func<object?, bool>? _canExecute;

        /// <summary>
        /// コマンド実行可否変更イベント
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DelegateCommand(Action<object?>? execute, Func<object?, bool>?canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// CanExecuteChangedイベントを発行します。
        /// </summary>
        public static void RaiseCanExecuteChange()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// コマンドの実行可否を判定します。
        /// </summary>
        /// <param name="parameter">コマンドパラメータ</param>
        /// <returns>コマンドが実行可能な時はtrueを返します。実行不可の時はfalseを返します。</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// コマンドを実行します。
        /// </summary>
        /// <param name="parameter">コマンドパラメータ</param>
        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
