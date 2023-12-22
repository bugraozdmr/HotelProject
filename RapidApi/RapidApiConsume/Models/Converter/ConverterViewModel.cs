namespace RapidApiConsume.Models.Converter
{
	public class ConverterViewModel
	{
		// edit - paste as special -- json

		public Exchange_Rates[] exchange_rates { get; set; }
		public string base_currency { get; set; }
		public string base_currency_date { get; set; }
	
		// 3 tane deger var asıl lazım olan bunun altındakiler
		public class Exchange_Rates
		{
			public string exchange_rate_buy { get; set; }
			public string currency { get; set; }
		}

	}
}
