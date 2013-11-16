using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
	public class SqlHelper
	{
		private static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
		
		/// <summary>
		/// 执行sql查询，并返回受影响的行数
		/// </summary>
		/// <param name="sql">执行的sql语句</param>
		/// <param name="parameters">sql语句的参数</param>
		/// <returns>影响的行数</returns>
		public static int ExecuteNonQuery(string sql,params SqlParameter[] parameters)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = sql;
					cmd.Parameters.AddRange(parameters);
					return cmd.ExecuteNonQuery();
				}
			}
		}

		/// <summary>
		/// 执行sql查询，并返回第一行第一列的数据
		/// </summary>
		/// <param name="sql">执行的sql语句</param>
		/// <param name="parameters">sql语句的参数</param>
		/// <returns>第一行第一列的数据</returns>
		public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = sql;
					cmd.Parameters.AddRange(parameters);
					return cmd.ExecuteScalar();
				}
			}
		}

		/// <summary>
		/// 执行sql查询，并返回一个SqlDataReader对象
		/// </summary>
		/// <param name="sql">执行的sql语句</param>
		/// <param name="parameters">sql语句的参数</param>
		/// <returns>SqlDataReader对象</returns>
		public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = sql;
					cmd.Parameters.AddRange(parameters);
					return cmd.ExecuteReader();
				}
			}
		}

		/// <summary>
		/// 执行sql查询，并返回查询结果的表
		/// </summary>
		/// <param name="sql">执行的sql语句</param>
		/// <param name="parameters">sql语句的参数</param>
		/// <returns>SqlDataReader对象</returns>
		public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
		{
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				conn.Open();
				using (SqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandText = sql;
					cmd.Parameters.AddRange(parameters);
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					adapter.FillSchema(dt, SchemaType.Source);
					adapter.Fill(dt);
					return dt;
				}
			}
		}
	}
}
