using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Translation_v1.database;

namespace Translation_v1.Pl
{
    class Search

    {
        public Search()
        {

        }
        public DataTable S_search(string arword)
        {
            Connection ob = new Connection();
            DataTable dataTable = new DataTable();
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@arword", SqlDbType.NVarChar, 50);
            sqlParameter[0].Value = arword;
            ob.open();
            dataTable = ob.Reader("search", sqlParameter);
            ob.Close();
            return dataTable;
        }


        public DataTable Disc(string arword)
        {
            Connection ob = new Connection();
            DataTable dataTable = new DataTable();
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@arword", SqlDbType.NVarChar, 50);
            sqlParameter[0].Value = arword;
            ob.open();
            dataTable = ob.Reader("dis", sqlParameter);
            ob.Close();
            return dataTable;
        }

        public void addword(string coptword, string arword, string disword)
        {
            Connection ob = new Connection();            
            ob.open();
            SqlParameter[] sqlParameter = new SqlParameter[3];

            sqlParameter[0] = new SqlParameter("@coptword", SqlDbType.NVarChar, 50);
            sqlParameter[0].Value = coptword;

            sqlParameter[1] = new SqlParameter("@arword", SqlDbType.NVarChar, 50);
            sqlParameter[1].Value = arword;

            sqlParameter[2] = new SqlParameter("@disword", SqlDbType.NVarChar, 50);
            sqlParameter[2].Value = disword;

            
            ob.RUA("addword", sqlParameter);
            ob.Close();          
        }

        public DataTable GetID(string arword)
        {
            Connection ob = new Connection();
            DataTable dataTable = new DataTable();
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@arword", SqlDbType.NVarChar, 50);
            sqlParameter[0].Value = arword;
            ob.open();
            dataTable = ob.Reader("getid", sqlParameter);
            ob.Close();
            return dataTable;
        }


        public void uppdate(string coptword, string arword, string disword,int id)
        {
            Connection ob = new Connection();
            ob.open();
            SqlParameter[] sqlParameter = new SqlParameter[4];

            sqlParameter[0] = new SqlParameter("@coptword", SqlDbType.NVarChar, 50);
            sqlParameter[0].Value = coptword;

            sqlParameter[1] = new SqlParameter("@arword", SqlDbType.NVarChar, 50);
            sqlParameter[1].Value = arword;

            sqlParameter[2] = new SqlParameter("@disword", SqlDbType.NVarChar, 50);
            sqlParameter[2].Value = disword;

            sqlParameter[3] = new SqlParameter("@id", SqlDbType.Int);
            sqlParameter[3].Value = id;

            ob.RUA("updateword", sqlParameter);
            ob.Close();
        }

        public void delword(int id)
        {
            Connection ob = new Connection();
            ob.open();
            SqlParameter[] sqlParameter = new SqlParameter[1];            

            sqlParameter[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParameter[0].Value = id;

            ob.RUA("deletword", sqlParameter);
            ob.Close();
        }

        public DataTable coptsearch(string coptword)
        {
            Connection ob = new Connection();
            DataTable dataTable = new DataTable();
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter("@copword", SqlDbType.NVarChar, 50);
            sqlParameter[0].Value = coptword;
            ob.open();
            dataTable = ob.Reader("coptsearsh", sqlParameter);
            ob.Close();
            return dataTable;
        }

    }
}
