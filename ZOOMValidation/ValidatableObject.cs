using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ZOOMValidation
{
    public class ValidatableObject<T> : INotifyPropertyChanged
    {
        public ValidatableObject()
        {
            ValidationRules = new List<IValidationRule<T>>();
            AsyncValidationRules = new List<IAsyncValidationRule<T>>();
        }

        public List<IValidationRule<T>> ValidationRules { get; set; }
        public List<IAsyncValidationRule<T>> AsyncValidationRules { get; set; }
        public T Value
        {
            get => value;
            set
            {
                SetProperty(ref this.value, value);
                IsValid = true;
            }
        }
        private T value;

        public bool IsValid { get => isValid; set => SetProperty(ref isValid, value); }
        private bool isValid = true;

        public string Error { get => error; set => SetProperty(ref error, value); }
        private string error;
        public async Task<bool> Validate()
        {
            foreach (var rule in ValidationRules)
            {
                if (!rule.Check(Value))
                {
                    Error = rule.ErrorMessage;
                    return await Task.FromResult(IsValid = false);
                }
            }

            foreach (var asyncRule in AsyncValidationRules)
            {
                if (!await asyncRule.CheckAsync(Value))
                {
                    Error = asyncRule.ErrorMessage;
                    return IsValid = false;
                }
            }
            return await Task.FromResult(IsValid = true);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private bool SetProperty<T2>(ref T2 storage, T2 value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T2>.Default.Equals(storage, value)) return false;

            storage = value;
            RaisePropertyChanged(propertyName);

            return true;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
        #endregion
    }
}
