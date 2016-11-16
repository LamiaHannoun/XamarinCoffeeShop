using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CafeAUnEuro
{
	public class Parameters
	{

		[JsonProperty("dataset")]
		public IList<string> dataset { get; set; }

		[JsonProperty("timezone")]
		public string timezone { get; set; }

		[JsonProperty("rows")]
		public int rows { get; set; }

		[JsonProperty("format")]
		public string format { get; set; }

		[JsonProperty("facet")]
		public IList<string> facet { get; set; }
	}

	public class Fields
	{

		[JsonProperty("arrondissement")]
		public int arrondissement { get; set; }

		[JsonProperty("adresse")]
		public string adresse { get; set; }

		[JsonProperty("prix_salle")]
		public string prix_salle { get; set; }

		[JsonProperty("geoloc")]
		public IList<double> geoloc { get; set; }

		[JsonProperty("nom_du_cafe")]
		public string nom_du_cafe { get; set; }

		[JsonProperty("prix_terasse")]
		public string prix_terasse { get; set; }

		[JsonProperty("date")]
		public string date { get; set; }

		[JsonProperty("prix_comptoir")]
		public int prix_comptoir { get; set; }
	}

	public class Geometry
	{

		[JsonProperty("type")]
		public string type { get; set; }

		[JsonProperty("coordinates")]
		public IList<double> coordinates { get; set; }
	}

	public class Record
	{

		[JsonProperty("datasetid")]
		public string datasetid { get; set; }

		[JsonProperty("recordid")]
		public string recordid { get; set; }

		[JsonProperty("fields")]
		public Fields fields { get; set; }

		[JsonProperty("geometry")]
		public Geometry geometry { get; set; }

		[JsonProperty("record_timestamp")]
		public string record_timestamp { get; set; }
	}

	public class Facet
	{

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("path")]
		public string path { get; set; }

		[JsonProperty("count")]
		public int count { get; set; }

		[JsonProperty("state")]
		public string state { get; set; }
	}

	public class FacetGroup
	{

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("facets")]
		public IList<Facet> facets { get; set; }
	}

	public class Example
	{

		[JsonProperty("nhits")]
		public int nhits { get; set; }

		[JsonProperty("parameters")]
		public Parameters parameters { get; set; }

		[JsonProperty("records")]
		public IList<Record> records { get; set; }

		[JsonProperty("facet_groups")]
		public IList<FacetGroup> facet_groups { get; set; }
	}

	public class Model
	{
		public Model()
		{
		}
	}
}
