using PropertySearch.Models;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PropertySearch.DataAccess
{
	public class DataAccess : IDataAccess
	{
		private static SqlConnection _connection ;

		public Sales GetLatestSaleForProperty( int propertyId )
		{
			using( var conn = GetConnection() )
			{
				return conn.QueryFirstOrDefault<Sales>( "select top 1 * from [Sales] where [Id] = {0} order by [SaleDate] desc", propertyId );
			}
		}

		public List<Sales> GetSalesForProperty( int propertyId )
		{
			using( var conn = GetConnection() )
			{
				return conn.Query<Sales>( "select * from [Sales] where [PropertyId] = {0}", propertyId ).AsList();
			}
		}

		public Property GetPropertyById ( int id )
		{			
			using (var conn = GetConnection() )
			{
				return conn.QueryFirstOrDefault<Property>( "select * from [Property] where id = {0}", id );
			}	

		}

		public List<Property> GetAllProperties()
		{
			using( var conn = GetConnection() )
			{
				return conn.Query<Property>( "select * from [Property]" ).AsList();
			}
		}
		public List<Property> GetAllPropertiesByPostcode(string postcode)
		{
			using( var conn = GetConnection() )
			{
				return conn.Query<Property>( "select * from [Property] where [Postcode] = '{0}' ", postcode ).AsList();
			}
		}

		private static SqlConnection GetConnection()
		{
			if( _connection == null )
			{
				_connection = new SqlConnection( "Data Source=DEVCLIENT-37;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False" );
			}
			return _connection;
		}

	}
}
