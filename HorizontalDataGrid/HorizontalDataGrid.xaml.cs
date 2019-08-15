using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using HorizontalDataGrid;

namespace HorizontalDataGridControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class HorizontalDataGrid : UserControl
    {
        private readonly GridViewModel _db = new GridViewModel();

        public HorizontalDataGrid()
        {
            InitializeComponent();
            DataGrid.DataContext = _db;
        }


        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            PopulateColumns();
        }

        private void PopulateColumns()
        {
            var items = _db.Parameters;
            DataGrid.Columns.Clear();

            if (items == null) return;

            var cellTemplate = (DataTemplate)this.DataGrid.FindResource("cellTemplate");
            foreach (dynamic item in items)
            {
                var index = 0;
                foreach (var col in item.Values)
                {
                    DataGrid.Columns.Add(new DataGridBoundTemplateColumn
                    {
                        Header = $"Pipe {index + 1}",
                        CellTemplate = cellTemplate,
                        BindingPath = $"Values[{index++}]"
                    });
                }

                break;
            }
        }

        public class DataGridBoundTemplateColumn : DataGridTemplateColumn
        {
            public string BindingPath { get; set; }

            protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
            {
                var element = base.GenerateEditingElement(cell, dataItem);
                element.SetBinding(ContentPresenter.ContentProperty, new Binding(this.BindingPath));
                return element;
            }

            protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
            {
                var element = base.GenerateElement(cell, dataItem);
                element.SetBinding(ContentPresenter.ContentProperty, new Binding(this.BindingPath));
                return element;
            }
        }
    }
}
