#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System.Windows.Interactivity;

namespace FilteringDemo
{
    public class DataGridBehavior : Behavior<SfDataGrid>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            (this.AssociatedObject as SfDataGrid).Loaded += OnLoaded;
            base.OnAttached();
        }

        /// <summary>
        /// Occurs when the SfDataGrid is rendered and ready for interaction.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs</param>
        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = this.AssociatedObject.DataContext as EmployeeInfoViewModel;
            viewModel.filterChanged = OnFilterChanged;
        }

        /// <summary>
        /// occurs when filter changed.
        /// </summary>
        private void OnFilterChanged()
        {
            var sfGrid = this.AssociatedObject as SfDataGrid;
            var viewModel = this.AssociatedObject.DataContext as EmployeeInfoViewModel;
            if (sfGrid.View != null)
            {
                sfGrid.View.Filter = viewModel.FilerRecords;
                sfGrid.View.RefreshFilter();
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            (this.AssociatedObject as SfDataGrid).Loaded -= OnLoaded;
            base.OnDetaching();
        }
    }
}
