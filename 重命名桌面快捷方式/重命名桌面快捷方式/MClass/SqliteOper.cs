using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace UsualLib
{
    public class SqliteOper
    {
        #region var
        private string DbConnStr { get; set; }

        private string DbPath { get; set; }
        #endregion

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
                    string sqlCheckTable = string.Format("SELECT COUNT(*) FROM sqlite_master where type='table' and name='RenameSC'");
                    SQLiteCommand slcmd = new SQLiteCommand(sqlCheckTable, slcon);
                    int iResult = Convert.ToInt32(slcmd.ExecuteScalar());
                    if (iResult == 0)
                    {
                        
                        string sqlCreateTable = string.Format(@"
    CREATE TABLE RenameSC
(
MainId NVARCHAR(36) NOT NULL,
FullPath NVARCHAR(4000) NOT NULL,
IsSpec BOOL,
SpecName NVARCHAR(4000),
OldName NVARCHAR(4000),
NewName NVARCHAR(4000)
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

        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="containSpec"></param>
        /// <param name="specDirName"></param>
        /// <returns></returns>
        public bool ExistsItem(string fullPath, bool containSpec, string specDirName)
        {
            bool bContain = false;

            DataTable dtTmp = new DataTable();
            string strSql = string.Format(@"
SELECT COUNT(*) AS MyCount FROM  RenameSC where FullPath=@FullPath 
AND  IsSpec=@IsSpec 
AND SpecName=@SpecName 
COLLATE NOCASE;");

            SQLiteConnection slcon = null;
            try
            {
                 
                slcon = new SQLiteConnection(DbConnStr);
                slcon.Open();

                SQLiteCommand slcmd = new SQLiteCommand(strSql, slcon);
                slcmd.Parameters.Add(new SQLiteParameter("@FullPath", fullPath));
                slcmd.Parameters.Add(new SQLiteParameter("@IsSpec", containSpec));
                slcmd.Parameters.Add(new SQLiteParameter("@SpecName", specDirName));

                object objRes = slcmd.ExecuteScalar();
                int iRes = int.Parse( objRes.ToString());
                if (iRes > 0)
                {
                    bContain = true;
                }
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

            return bContain;
        }

        public bool InsertGameDoc(string MainId, string FullPath, bool IsSpec, string SpecName, string newName)
        {
            string strSql = string.Format(@"
INSERT INTO RenameSC
(
    MainId,FullPath,IsSpec,SpecName,NewName
)
VALUES 
(
    @MainId,@FullPath,@IsSpec,@SpecName,@NewName)
");

            SQLiteConnection slcon = null;
            try
            {
                slcon = new SQLiteConnection(DbConnStr);
                slcon.Open();

                SQLiteCommand slcmd = new SQLiteCommand(strSql, slcon);
                slcmd.Parameters.Add(new SQLiteParameter("@MainId", MainId));
                slcmd.Parameters.Add(new SQLiteParameter("@FullPath", FullPath));

                slcmd.Parameters.Add(new SQLiteParameter("@IsSpec", IsSpec));
                slcmd.Parameters.Add(new SQLiteParameter("@SpecName", SpecName));
                slcmd.Parameters.Add(new SQLiteParameter("@NewName", newName));

                slcmd.ExecuteNonQuery();
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

            return true;
        }

       
        public DataTable GetGameDocList()
        {
            DataTable dtTmp = new DataTable();
            string strSql = string.Format(@"
SELECT * FROM  RenameSC  ");

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
DELETE FROM  RenameSC 
where MainId=@MainId 
");

            SQLiteConnection slcon = null;
            try
            {
                slcon = new SQLiteConnection(DbConnStr);
                slcon.Open();

                SQLiteCommand slcmd = new SQLiteCommand(strSql, slcon);
                slcmd.Parameters.Add(new SQLiteParameter("@MainId", gdid));

                slcmd.ExecuteNonQuery();
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

            return true;
        }

       
    }
}
