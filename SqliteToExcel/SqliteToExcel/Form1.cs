using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SqliteToExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDB.Text = Application.StartupPath + @"\sale.db";
             
            txtExcel.Text = Application.StartupPath + @"\25-28ca.xls";

            txtSql.Text = "select * from t_rm_cashier_payflow where oper_date between '2013-11-25 00:00:00' and '2013-11-29 00:00:00'";

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportData();
        }


        private void ExportData()
        {
            string dbPosSaleFileName = txtDB.Text;
            string strDbItemConn = "Data Source=" + dbPosSaleFileName + ";Emulator=True;Encoding=UTF8;";
            string excelFileName = txtExcel.Text;

            string sql = txtSql.Text;
            using (SQLiteConnection sconn = new SQLiteConnection(strDbItemConn))
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(sql,sconn);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                SetXlsData(ds.Tables[0], excelFileName);
            }

        }

        // <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="saveFileName"></param>
        /// <returns></returns>
        public static bool SetXlsData(DataTable dt, string saveFileName)
        {

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel", "");
                return false;
            }

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 


            //写入标题[隐藏列名/列名为空]
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
            }

            //写入数值
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    if (dt.Columns[i].DataType == typeof(string))
            //    {
            //        Microsoft.Office.Interop.Excel.Range workrange =
            //            worksheet.get_Range(worksheet.Cells[2, i + 1], worksheet.Cells[dt.Rows.Count + 1, i + 1]);
            //        workrange.NumberFormatLocal = "@";     //设置单元格格式为文本 
            //    }
            //    for (int r = 0; r < dt.Rows.Count; r++)
            //    {
            //        worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
            //    }
            //    System.Windows.Forms.Application.DoEvents();
            //}
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns[i].DataType == typeof(string))
                    {
                        Microsoft.Office.Interop.Excel.Range workrange =
                            worksheet.get_Range(worksheet.Cells[r + 2, i + 1], worksheet.Cells[r + 2, i + 1]);
                        workrange.NumberFormatLocal = "@";     //设置单元格格式为文本 
                    }

                    worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应

            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    //workbook.SaveCopyAs(saveFileName);
                    //Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8：Excel97-2003格式
                    //Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12：Excel2007格式
                    workbook.SaveAs(saveFileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    //fileSaved = true;
                }
                catch (Exception ex)
                {
                    //fileSaved = false;
                    MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message, "");
                }

            }
            xlApp.Quit();
            GC.Collect();//强行销毁 

            return true;
        }

        
    }
}
