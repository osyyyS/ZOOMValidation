using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ZOOMValidation.Pair
{
    public class ValidatablePair<T> : INotifyPropertyChanged
    {
        public ValidatablePair(ValidatableObject<T> item1, ValidatableObject<T> item2)
        {
            PairValidationRules = new List<IPairValidationRule<T>>();
            AsyncPairValidationRules = new List<IAsyncPairValidationRule<T>>();
            Item1 = item1;
            Item2 = item2;
        }

        public List<IPairValidationRule<T>> PairValidationRules { get; }
        public List<IAsyncPairValidationRule<T>> AsyncPairValidationRules { get; }
        public ValidatableObject<T> Item1 { get; }
        public ValidatableObject<T> Item2 { get; }

        public bool IsValid { get => isValid; set => SetProperty(ref isValid, value); }
        private bool isValid = true;

        public string Error { get => error; set => SetProperty(ref error, value); }
        private string error;
        public async Task<bool> Validate()
        {
            foreach (var rule in PairValidationRules)
            {
                if (!rule.Check(Item1.Value, Item2.Value))
                {
                    Error = rule.ErrorMessage;
                    return await Task.FromResult(IsValid = false);
                }
            }

            foreach (var asyncRule in AsyncPairValidationRules)
            {
                if (!await asyncRule.CheckAsync(Item1.Value, Item2.Value))
                {
                    Error = asyncRule.ErrorMessage;
                    return IsValid = false;
                }
            }

            if (!await Item1.Validate())
            {
                Error = Item1.Error;
                return IsValid = false;
            }

            if (!await Item2.Validate())
            {
                Error = Item2.Error;
                return IsValid = false;
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
