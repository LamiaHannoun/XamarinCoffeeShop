using System;
using System.Collections.Generic;
using System.Globalization;
using Foundation;
using UIKit;

namespace CafeAUnEuro.iOS
{
	public class CoffeeTableSource : UITableViewSource
	{
		private const string cellIdentifier = "coffeeItemId";
		private CoffeeTableViewController _controller;
		private IList<Record> _records;


		public CoffeeTableSource(CoffeeTableViewController controller, IList<Record> records)
		{
			_controller = controller;
			SetItems(records);
		}

		private void SetItems(IList<Record> source)
		{
			_records = new List<Record>(source ?? new List<Record>());
			_controller.TableView.ReloadData();
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			_controller.OnRecordSelected(_records[indexPath.Row]);
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(cellIdentifier);

			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle , cellIdentifier);
			}

			var record = _records[indexPath.Row];

			cell.TextLabel.Text = record.fields.nom_du_cafe;
			cell.DetailTextLabel.Text = record.fields.adresse;
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _records.Count;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_controller = null;
			}
			base.Dispose(disposing);
		}
	}
}
