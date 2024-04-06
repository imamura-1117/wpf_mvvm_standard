using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFMVVMStandard.ViewModels
{
    /// <summary>
    /// ViewModelの基底クラス
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// 通知イベント
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// プロパティの変更を通知します。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected void NotifyPropertyChanged([CallerMemberName]string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// プロパティを設定します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">設定されるフィールド</param>
        /// <param name="value">設定する値</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T field, T value,
            [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
            {

                return false;

            }

            field = value;

            NotifyPropertyChanged(propertyName);

            return true;

        }
    }
}
