using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace HorizontalDataGrid
{
    public class GridViewModel : BindableBase
    {
        public GridViewModel()
        {
            Parameters =
                new ObservableCollection<ParametersViewModel>
                {
                    new ParametersViewModel(new[] {0.1, 0.1, 0.1, 0.1, 0.1})
                    {
                        Header = "Row1"
                    },
                    new ParametersViewModel(
                        new[] {0, 0.1, -1, -1, -1},
                        new[] {true, true, false, false, false},
                        new[] {true, false, false, false, false}
                        )
                    {
                        Header = "Row2"
                    }
                };

        }

        public ObservableCollection<ParametersViewModel> Parameters { get; }
    }
}
