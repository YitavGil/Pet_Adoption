using Microsoft.EntityFrameworkCore;

namespace Pet_Adoption.DAL
{
	public class Data
	{
		public static string ConnectionString = "server=YITAV\\SQLEXPRESS;initial catalog=Pet_Adoption; user id=sa;" +
			"password=1234;TrustServerCertificate=Yes";
		private static DataLayer _dataLayer;

		public static DataLayer Get
		{
			get
			{
				if (_dataLayer == null)
				{
					var options = new DbContextOptionsBuilder<DataLayer>()
						.UseSqlServer(ConnectionString)
						.Options;
					_dataLayer = new DataLayer(options);
				}
				return _dataLayer;
			}
		}
	}
}