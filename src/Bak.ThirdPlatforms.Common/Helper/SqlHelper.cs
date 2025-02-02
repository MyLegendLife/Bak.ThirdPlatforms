﻿using Bak.ThirdPlatforms.Domain.Settings;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Bak.ThirdPlatforms.Common.Helper
{
    public class SqlHelper
    {
        public SqlHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        private static string sqlConnectionString
        {
            get
            {
                return AppSettings.Bak.ConnectionString;
            }
        }
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns>Conn</returns>
        private static SqlConnection sqlConn
        {
            get
            {
                string ConnStrings = sqlConnectionString;
                SqlConnection Conn = new SqlConnection();
                Conn.ConnectionString = ConnStrings;
                return Conn;
            }
        }

        /// <summary>
        /// 执行sql语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">sql语句参数</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string sqlString)
        {
            DataSet dsSet = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter(sqlString, sqlConnectionString);
            try
            {
                adp.Fill(dsSet);
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                adp.Dispose();
            }
            return dsSet;
        }

        /// <summary>
        /// 执行sql语句，返回DataTable
        /// </summary>
        /// <param name="sqlString">sql语句参数</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string sqlString)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(sqlString, sqlConnectionString);
            try
            {
                adp.Fill(dt);
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                adp.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 执行存储过程返回DataSet
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(string spName, SqlParameter[] commandParameters)
        {
            SqlConnection conn = sqlConn;
            conn.Open();
            SqlCommand sqlcommand = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();
            sqlcommand.Connection = conn;
            sqlcommand.CommandText = spName;
            sqlcommand.CommandType = CommandType.StoredProcedure;
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                    {
                        p.Value = DBNull.Value;
                    }
                    sqlcommand.Parameters.Add(p);
                }
            }
            adapter.SelectCommand = sqlcommand;
            try
            {
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                sqlcommand.Parameters.Clear();
                sqlcommand.Dispose();
                adapter.Dispose();
                conn.Close();
            }
            return dataSet;
        }

        /// <summary>
        /// 执行存储过程返回DataTable
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string spName, SqlParameter[] commandParameters)
        {
            SqlConnection conn = sqlConn;
            conn.Open();
            SqlCommand sqlcommand = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            sqlcommand.Connection = conn;
            sqlcommand.CommandText = spName;
            sqlcommand.CommandType = CommandType.StoredProcedure;
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                    {
                        p.Value = DBNull.Value;
                    }
                    sqlcommand.Parameters.Add(p);
                }
            }
            adapter.SelectCommand = sqlcommand;
            try
            {
                adapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                sqlcommand.Parameters.Clear();
                sqlcommand.Dispose();
                adapter.Dispose();
                conn.Close();
            }
            return dataTable;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>true or false</returns>
        public static bool ExecuteProcedure(string spName, SqlParameter[] commandParameters)
        {
            bool result = false;
            SqlConnection conn = sqlConn;
            conn.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = conn;
            sqlcommand.CommandText = spName;
            sqlcommand.CommandType = CommandType.StoredProcedure;
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                    {
                        p.Value = DBNull.Value;
                    }
                    sqlcommand.Parameters.Add(p);
                }
            }
            try
            {
                sqlcommand.ExecuteNonQuery();
                result = true;
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                sqlcommand.Parameters.Clear();
                sqlcommand.Dispose();
                conn.Close();
            }
            return result;
        }

        /// <summary>
        /// 执行存储过程返回一个object对象
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>object</returns>
        public static object ExecuteProcedures(string spName, SqlParameter[] commandParameters)
        {
            object ret = new object();
            ret = DBNull.Value;
            SqlConnection conn = sqlConn;
            conn.Open();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandText = spName;
            sqlcommand.CommandType = CommandType.StoredProcedure;
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                    {
                        p.Value = DBNull.Value;
                    }
                    sqlcommand.Parameters.Add(p);
                }
            }
            try
            {
                ret = sqlcommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                sqlcommand.Parameters.Clear();
                sqlcommand.Dispose();
                conn.Close();
            }
            return ret;
        }

        /// <summary>
        /// 执行sql语句，返回一个object对象
        /// </summary>
        /// <param name="sqlString">自定义sql语句</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string sqlString)
        {
            object ret = new object();
            ret = DBNull.Value;
            SqlConnection conn = sqlConn;
            conn.Open();
            SqlCommand sqlcommand = new SqlCommand(sqlString, conn);
            try
            {
                ret = sqlcommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                sqlcommand.Dispose();
                conn.Close();
            }
            return ret;
        }

        /// <summary>
        /// 执行自定义sql语句
        /// </summary>
        /// <param name="sqlString">自定sql语句</param>
        /// <returns>true or false</returns>
        public static bool ExecuteNoQueryString(string sqlString)
        {
            bool result = false;

            SqlConnection conn = sqlConn;
            conn.Open();
            SqlCommand sqlcommand = new SqlCommand(sqlString, conn);
            try
            {
                sqlcommand.ExecuteScalar();
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                sqlcommand.Dispose();
                conn.Close();
            }
            return result;
        }
    }
}