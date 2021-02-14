#region (c) 2019 Gilles Macabies All right reserved

//   Author     : Gilles Macabies
//   Solution   : DataGridFilter
//   Projet     : DataGridFilter
//   File       : MainWindow.xaml.cs
//   Created    : 31/10/2019

#endregion (c) 2019 Gilles Macabies All right reserved

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
// ReSharper disable RedundantExtendsListEntry

namespace DemoApplication
{
    /// <summary>
    ///     Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class DataGridNumericColumn : DataGridTextColumn
        {
            protected override object PrepareCellForEdit(System.Windows.FrameworkElement editingElement, System.Windows.RoutedEventArgs editingEventArgs)
            {
                TextBox edit = editingElement as TextBox;
                edit.PreviewTextInput += OnPreviewTextInput;

                return base.PrepareCellForEdit(editingElement, editingEventArgs);
            }

            void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
            {
                try
                {
                    Convert.ToInt32(e.Text);
                }
                catch
                {
                    // Show some kind of error message if you want

                    // Set handled to true
                    e.Handled = true;
                }
            }
        }
        #region Public Constructors

        public MainWindow()
        {
            InitializeComponent();

#if DEBUG
            AppDomain.CurrentDomain.FirstChanceException += (source, e) =>
            {
                Debug.WriteLine("FirstChanceException event raised in {0}: {1}",
                    AppDomain.CurrentDomain.FriendlyName, e.Exception.Message);
            };
#endif
            DataContext = new ModelView.ModelView();
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Add line numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var index = e.Row.GetIndex() + 1;
            e.Row.Header = $"{index}";
        }

        #endregion Private Methods

        private void FilterDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Save Update 
            if (e.EditAction == DataGridEditAction.Commit)
            {
            }
        }

        private void FilterDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                //if (InterventionsViewModel.Current.SelectedIntervention != null)
                //{
                //    InterventionsViewModel.Current.SaveSelectedIntervention();

                //}
            }
        }
    }

}
