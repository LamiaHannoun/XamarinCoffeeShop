using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace CafeAUnEuro.Droid
{
	public class ViewHolder : Java.Lang.Object
	{
		public TextView CoffeNameTextView { get; private set; }
		public TextView CoffeeAddressTextView { get; private set; }
		public TextView CoffeeZipCodeTextView { get; private set; }

		public ViewHolder(View view)
		{
			var coffeeName = view.FindViewById<TextView>(Resource.Id.coffeeName);
			var coffeeAddress = view.FindViewById<TextView>(Resource.Id.coffeeAddress);
			var CoffeeZipCode = view.FindViewById<TextView>(Resource.Id.coffeeZipCode);

			this.CoffeNameTextView = coffeeName;
			this.CoffeeAddressTextView = coffeeAddress;
			this.CoffeeZipCodeTextView = CoffeeZipCode;
		}

	}

	public class CoffeeListAdapter : BaseAdapter<Record>
	{
		private readonly List<Record> items;
		public CoffeeListAdapter(IEnumerable<Record> source)
		{
			items = new List<Record>(source ?? new List<Record>());
			SetItems(source);
		}

		public void SetItems(IEnumerable<Record> source) 
		{
			items.Clear();
			items.AddRange(new List<Record>(source ?? new List<Record>()));
			NotifyDataSetChanged();
		}
		public override Record this[int position] => items[position];

		public override int Count => items.Count;

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
			{
				view = LayoutInflater.FromContext(parent.Context)
							  		 .Inflate(Resource.Layout.CoffeeItemDataTemplate,null);

				view.Tag = new ViewHolder(view);
			}

			var coffeeNameTextView = ((ViewHolder)view.Tag).CoffeNameTextView;
			var coffeeAddressTextView = ((ViewHolder)view.Tag).CoffeeAddressTextView;
			var coffeeZipCodeTextView = ((ViewHolder)view.Tag).CoffeeZipCodeTextView;


			coffeeNameTextView.Text = items[position].fields.nom_du_cafe;
			coffeeAddressTextView.Text = items[position].fields.adresse;
			coffeeZipCodeTextView.Text = items[position].fields.arrondissement.ToString();
			return view;
		}
	}
}
