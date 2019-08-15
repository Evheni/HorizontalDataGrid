using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace HorizontalDataGrid
{
    public class ParametersViewModel : BindableBase
    {
        private string _header;

        public ParametersViewModel(IList<double> values, IList<bool> enabled = null, IList<bool> used = null)
        {
            for (var i = 0; i < values.Count; i++)
            {
                Add(
                    values[i],
                    !(enabled?.Count > i) || enabled[i],
                    !(used?.Count > i) || used[i]);
            }
        }

        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        public ObservableCollection<ParameterViewModel> Values { get; } = new ObservableCollection<ParameterViewModel>();

        public void Add(double value, bool enabled = true, bool used = true)
        {
            Values.Add(new ParameterViewModel
            {
                IsEnabled = enabled,
                IsUsed = used,
                Value = value
            });
        }
    }
}