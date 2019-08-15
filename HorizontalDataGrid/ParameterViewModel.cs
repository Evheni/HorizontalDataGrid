using Prism.Mvvm;

namespace HorizontalDataGrid
{
    public class ParameterViewModel : BindableBase
    {
        public double Value { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsUsed { get; set; }
    }
}