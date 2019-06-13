//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using Prism.Regions;
using Prism.Regions.Behaviors;
using System.Collections.Specialized;
using System.Windows;

namespace WpfTemplate.Behaviors
{
    /// <summary>
    /// Defines a behavior that creates a Dialog to display the active view of the target <see cref="IRegion"/>.
    /// </summary>
    public abstract class DialogActivationBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        /// <summary>
        /// The key of this behavior
        /// </summary>
        public const string BehaviorKey = "DialogActivation";

        private IWindow contentDialog;

        /// <summary>
        /// Gets or sets the <see cref="DependencyObject"/> that the <see cref="IRegion"/> is attached to.
        /// </summary>
        /// <value>A <see cref="DependencyObject"/> that the <see cref="IRegion"/> is attached to.
        /// This is usually a <see cref="FrameworkElement"/> that is part of the tree.</value>
        public DependencyObject HostControl { get; set; }

        /// <summary>
        /// Performs the logic after the behavior has been attached.
        /// </summary>
        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        /// <summary>
        /// Override this method to create an instance of the <see cref="IWindow"/> that 
        /// will be shown when a view is activated.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IWindow"/> that will be shown when a 
        /// view is activated on the target <see cref="IRegion"/>.
        /// </returns>
        protected abstract IWindow CreateWindow();

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                CloseContentDialog();
                PrepareContentDialog(e.NewItems[0]);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                CloseContentDialog();
            }
        }

        private Style GetStyleForView()
        {
            return HostControl.GetValue(RegionPopupBehaviors.ContainerWindowStyleProperty) as Style;
        }

        private void PrepareContentDialog(object view)
        {
            contentDialog = CreateWindow();
            contentDialog.Content = view;
            contentDialog.Owner = HostControl;
            contentDialog.Closed += ContentDialogClosed;
            contentDialog.Style = GetStyleForView();
            contentDialog.Show();
        }

        private void CloseContentDialog()
        {
            if (contentDialog != null)
            {
                contentDialog.Closed -= ContentDialogClosed;
                contentDialog.Close();
                contentDialog.Content = null;
                contentDialog.Owner = null;
            }
        }

        private void ContentDialogClosed(object sender, System.EventArgs e)
        {
            Region.Remove(contentDialog.Content);
            CloseContentDialog();
        }
    }
}