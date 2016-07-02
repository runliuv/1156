using System;
using System.Collections.Generic;
 
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace GameArchiveBak
{
    public class SqliteOper
    {
        private string DbConnStr { get; set; }

        private string DbPath { get; set; }

        /// <summary>
        /// dbPath 数据库的完整路径，如： d:\temp\aa.db 。
        /// </summary>
        /// <param name="dbPath"></param>
        public SqliteOper(string dbPath)
        {
            DbPath = dbPath;
            DbConnStr = @"Data Source=" + dbPath + @";Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";
        }

        /// <summary>
        /// 检查数据库、表。若没有则创建。
        /// </summary>
        /// <returns></returns>
        public bool CheckDb()
        {
            if (!File.Exists(DbPath))
            {
                try
                {
                    SQLiteConnection.CreateFile(DbPath);
                }
                catch (Exception exp)
                {
                    return false;
                }
            }

            if (File.Exists(DbPath))
            {
                //检查表是否存在
                SQLiteConnection slcon = null;
                try
                {
                    slcon = new SQLiteConnection(DbConnStr);
                    slcon.Open();
                    string sqlCheckTable = string.Format("SELECT COUNT(*) FROM sqlite_master where type='table' and name='GameDoc'");
                    SQLiteCommand slcmd = new SQLiteCommand(sqlCheckTable, slcon);
                    int iResult = Convert.ToInt32(slcmd.ExecuteScalar());
                    if (iResult == 0)
                    {
                        //DocTarget 备份位置 e:\temp\
                        //DocTargetFull  完整备份位置 e:\temp\AA   或 e:\temp\AA.zip
                        string sqlCreateTable = string.Format(@"
    CREATE TABLE GameDoc
(
gdid NVARCHAR(36) NOT NULL,
DocDescr NVARCHAR(4000) NOT NULL,
DocSource NVARCHAR(4000) NOT NULL,
DocTarget NVARCHAR(4000) NOT NULL,
DocTargetFull NVARCHAR(4000) NOT NULL,
IncludeSpecDir BOOL,
SpecDirName NVARCHAR(4000)
)
");
                        slcmd.CommandText = sqlCreateTable;
                        slcmd.ExecuteNonQuery();
                    }

                }
                catch (Exception exp)
                {
                    return false;
                }
                finally
                {
                    if (slcon != null)
                    {
                        slcon.Close();
                    }
                }
            }

            return true;
        }

        public bool InsertGameDoc(string gdid, string DocDescr, string DocSource, string DocTarget, string DocTargetFull, bool IncludeSpecDir, string SpecDirName)
        {
            string strSql = string.Format(@"
INSERT INTO GameDoc
(
gdid,DocDescr,DocSource,DocTarget,
DocTargetFull,IncludeSpecDir,SpecDirName
)
VALUES 
(@gdid,@DocDescr,@DocSource,@DocTarget,
@DocTargetFull,@IncludeSpecDir,@SpecDirName)
");
             
            SQLiteConnection slcon = null;
            try
            {
                slcon = new SQLiteConnection(DbConnStr);
                slcon.Open();

                SQLiteCommand slcmd = new SQLiteCommand(strSql, slcon);
                slcmd.Parameters.Add(new SQLiteParameter("@gdid", gdid));
                slcmd.Parameters.Add(new SQLiteParameter("@DocDescr", DocDescr));
                slcmd.Parameters.Add(new SQLiteParameter("@DocSource", DocSource));
                slcmd.Parameters.Add(new SQLiteParameter("@DocTarget", DocTarget));

                slcmd.Parameters.Add(new SQLiteParameter("@DocTargetFull", DocTargetFull));
                slcmd.Parameters.Add(new SQLiteParameter("@IncludeSpecDir", IncludeSpecDir));
                slcmd.Parameters.Add(new SQLiteParameter("@SpecDirName", SpecDirName));

                slcmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {
                if (slcon != null)
                {
                    slcon.Close();
                }
            }

            return true;
        }

        public bool UpdateGameDoc(string gdid, string DocDescr, string DocSource, string DocTarget, string DocTargetFull, bool IncludeSpecDir, string SpecDirName)
        {
            string strSql = string.Format(@"
Update GameDoc SET 
    DocDescr=@DocDescr,DocSource=@DocSource,DocTarget=@DocTarget,
    DocTargetFull=@DocTargetFull,IncludeSpecDir=@IncludeSpecDir,SpecDirName=@SpecDirName
where gdid=@gdid 
");

            SQLiteConnection slcon = null;
            try
            {
                slcon = new SQLiteConnection(DbConnStr);
                slcon.Open();

                SQLiteCommand slcmd = new SQLiteCommand(strSql, slcon);
                slcmd.Parameters.Add(new SQLiteParameter("@gdid", gdid));
                slcmd.Parameters.Add(new SQLiteParameter("@DocDescr", DocDescr));
                slcmd.Parameters.Add(new SQLiteParameter("@DocSource", DocSource));
                slcmd.Parameters.Add(new SQLiteParameter("@DocTarget", DocTarget));

                slcmd.Parameters.Add(new SQLiteParameter("@DocTargetFull", DocTargetFull));
                slcmd.Parameters.Add(new SQLiteParameter("@IncludeSpecDir", IncludeSpecDir));
                slcmd.Parameters.Add(new SQLiteParameter("@SpecDirName", SpecDirName));

                slcmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {
                if (slcon != null)
                {
                    slcon.Close();
                }
            }

            return true;
        }

        public DataTable GetGameDocList()
        {
            DataTable dtTmp = new DataTable();
            string strSql = string.Format(@"
SELECT * FROM  GameDoc
 
");

            SQLiteConnection slcon = null;
            try
            {
                slcon = new SQLiteConnection(DbConnStr);
                slcon.Open();

                SQLiteCommand slcmd = new SQLiteCommand(strSql, slcon);
                SQLiteDataAdapter slda = new SQLiteDataAdapter(slcmd);
                slda.Fill(dtTmp);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (slcon != null)
                {
                    slcon.Close();
                }
            }

            return dtTmp;
        }

        public bool DeleteGameDoc(string gdid)
        {
            string strSql = string.Format(@"
DELETE FROM  GameDoc 
where gdid=@gdid 
");

            SQLiteConnection slcon = null;
            try
            {
                slcon = new SQLiteConnection(DbConnStr);
                slcon.Open();

                SQLiteCommand slcmd = new SQLiteCommand(strSql, slcon);
                slcmd.Parameters.Add(new SQLiteParameter("@gdid", gdid));
                 

                slcmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {
                if (slcon != null)
                {
                    slcon.Close();
                }
            }

            return true;
        }

        public bool UpdateTargetPathFull(string gdid, string DocTargetFull)
        {
            string strSql = string.Format(@"
Update GameDoc SET      
    DocTargetFull=@DocTargetFull 
where gdid=@gdid 
");

            SQLiteConnection slcon = null;
            try
            {
                slcon = new SQLiteConnection(DbConnStr);
                slcon.Open();

                SQLiteCommand slcmd = new SQLiteCommand(strSql, slcon);
                slcmd.Parameters.Add(new SQLiteParameter("@gdid", gdid));
                ;

                slcmd.Parameters.Add(new SQLiteParameter("@DocTargetFull", DocTargetFull));
                 

                slcmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                return false;
            }
            finally
            {
                if (slcon != null)
                {
                    slcon.Close();
                }
            }

            return true;
        }
    }
}
