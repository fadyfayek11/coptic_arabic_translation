using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration; 

namespace Translation_v1.database
{
    class Connection
    {
        SqlCommand cmd;
        SqlDataAdapter da;
        readonly SqlConnection cn;
        readonly DataTable dt = new DataTable();
        string path = Environment.CurrentDirectory;

        /*  باني افتراضي لاجل بناء اتصال */
        public Connection()
        {
            cn = new SqlConnection(@$"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = {path}\coptic.mdf; Integrated Security = True; Connect Timeout = 30");
        }
        public void open()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }

        public void Close()
        {
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }
        //تابع لقراءة البيانات من قاعدة البيانات
        public DataTable Reader(string sp, SqlParameter[] p)
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = cn;
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;


        }
        //Remove ,Update ,Add
        public void RUA(string sp, SqlParameter[] p)
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = cn;
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            cmd.ExecuteNonQuery();

        }

        
      
    }
}
