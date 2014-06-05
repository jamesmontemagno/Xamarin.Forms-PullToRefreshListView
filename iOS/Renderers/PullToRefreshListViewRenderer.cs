using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PullToRefresh.iOS.Renderers;
using PullToRefresh;
using MonoTouch.UIKit;

[assembly:ExportRendererAttribute(typeof(PullToRefreshListView), typeof(PullToRefreshListViewRenderer))]
namespace PullToRefresh.iOS.Renderers
{
	public class PullToRefreshListViewRenderer : ListViewRenderer
	{
		public PullToRefreshListViewRenderer ()
		{
		}

		private FormsUIRefreshControl refreshControl;
		protected override void OnModelSet(VisualElement model)
		{
			base.OnModelSet(model);

			var pullToRefreshListView = (PullToRefreshListView)this.Model; 
			var tableView = (UITableView) this.Control;

			refreshControl = new FormsUIRefreshControl ();
			refreshControl.RefreshCommand = pullToRefreshListView.RefreshCommand;
			refreshControl.Message = pullToRefreshListView.Message;
			tableView.AddSubview (refreshControl);
		}


		/// <summary>
		/// Called when the underlying model's properties are changed
		/// </summary>
		/// <param name="sender">Model</param>
		/// <param name="e">Event arguments</param>
		protected override void OnHandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnHandlePropertyChanged(sender, e);

			var pullToRefreshListView = (PullToRefreshListView)this.Model; 
	

			if (e.PropertyName == PullToRefreshListView.IsRefreshingProperty.PropertyName) {
				refreshControl.IsRefreshing = pullToRefreshListView.IsRefreshing;
			} else if (e.PropertyName == PullToRefreshListView.MessageProperty.PropertyName) {
				refreshControl.Message = pullToRefreshListView.Message;
			} else if (e.PropertyName == PullToRefreshListView.RefreshCommandProperty.PropertyName) {
				refreshControl.RefreshCommand = pullToRefreshListView.RefreshCommand;
			}
		}
	}
}

