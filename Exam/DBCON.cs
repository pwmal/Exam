using Npgsql;
using System.Data;

namespace Exam
{
    public class DBCON
    {
        public static DataSet ds;
        public static DataTable dt;
        public static NpgsqlConnection connString = new NpgsqlConnection("Host=localhost;Port=5432;Database=exam;Username=postgres;Password=1234");

        public static void SQLtoDB(string sql)
        {
            DBCON.connString.Open();
            NpgsqlDataAdapter dataAd = new NpgsqlDataAdapter(sql, connString);
            DBCON.ds = new DataSet();
            DBCON.ds.Reset();
            dataAd.Fill(ds);
            DBCON.dt = ds.Tables[0];
            connString.Close();
        }

        public static void SQLtoDBwithChanges(string sql)
        {
            connString.Open();
            NpgsqlCommand comm = new NpgsqlCommand(sql, connString);
            comm.ExecuteNonQuery();
            connString.Close();
        }
    }
}
