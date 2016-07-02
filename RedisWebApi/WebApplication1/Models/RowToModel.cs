using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebRedis.Models;

namespace WebApplication1.Models
{
    public class RowToModel
    {
        public static t_bd_item_info DataRowTot_bd_item_info(DataRow row)
        {
            t_bd_item_info model = new t_bd_item_info();


            model.item_subno = SIString.TryStr(row["item_subno"]);
            model.item_name = SIString.TryStr(row["item_name"]);
            model.item_subname = SIString.TryStr(row["item_subname"]);



            model.unit_no = SIString.TryStr(row["unit_no"]);
            model.item_size = SIString.TryStr(row["item_size"]);



            model.combine_sta = SIString.TryStr(row["combine_sta"]);
            model.status = SIString.TryStr(row["status"]);
            model.display_flag = SIString.TryStr(row["display_flag"]);
            model.po_cycle = SIString.TryInt(row["po_cycle"]);
            model.so_cycle = SIString.TryInt(row["so_cycle"]);
            model.automin_flag = SIString.TryStr(row["automin_flag"]);
            model.en_dis = SIString.TryStr(row["en_dis"]);
            model.change_price = SIString.TryStr(row["change_price"]);
            model.purchase_tax = SIString.TryDec(row["purchase_tax"]);
            model.sale_tax = SIString.TryDec(row["sale_tax"]);
            model.purchase_spec = SIString.TryDec(row["purchase_spec"]);
            model.shipment_spec = SIString.TryDec(row["shipment_spec"]);
            model.item_supcust = SIString.TryStr(row["item_supcust"]);
            model.main_supcust = SIString.TryStr(row["main_supcust"]);
            model.item_stock = SIString.TryStr(row["item_stock"]);



            model.abc = SIString.TryStr(row["abc"]);
            model.branch_price = SIString.TryStr(row["branch_price"]);
            model.item_rem = SIString.TryStr(row["item_rem"]);



            model.vip_acc_flag = SIString.TryStr(row["vip_acc_flag"]);
            model.vip_acc_num = SIString.TryDec(row["vip_acc_num"]);
            model.dpfm_type = SIString.TryStr(row["dpfm_type"]);
            model.return_rate = SIString.TryDec(row["return_rate"]);
            model.update_date = SIString.TryStr(row["update_date"]);
            model.pro_code1 = SIString.TryStr(row["pro_code1"]);
            model.pro_code2 = SIString.TryStr(row["pro_code2"]);
            model.pro_code3 = SIString.TryStr(row["pro_code3"]);
            model.pro_code4 = SIString.TryStr(row["pro_code4"]);
            model.pro_code5 = SIString.TryStr(row["pro_code5"]);
            model.pro_code6 = SIString.TryStr(row["pro_code6"]);
            model.item_picture = SIString.TryStr(row["item_picture"]);
            model.sale_flag = SIString.TryStr(row["sale_flag"]);





            model.valid_days = SIString.TryDec(row["valid_days"]);
            model.memo = SIString.TryStr(row["memo"]);
            model.item_com = SIString.TryStr(row["item_com"]);
            model.product_area = SIString.TryStr(row["product_area"]);
            model.measure_flag = SIString.TryStr(row["measure_flag"]);
            model.item_sup_flag = SIString.TryStr(row["item_sup_flag"]);
            model.sup_rate = SIString.TryDec(row["sup_rate"]);
            model.picture_type = SIString.TryStr(row["picture_type"]);
            model.base_price1 = SIString.TryDec(row["base_price1"]);
            model.base_price2 = SIString.TryDec(row["base_price2"]);
            model.base_price3 = SIString.TryDec(row["base_price3"]);
            model.base_price4 = SIString.TryDec(row["base_price4"]);
            model.base_price5 = SIString.TryDec(row["base_price5"]);
            model.base_price6 = SIString.TryDec(row["base_price6"]);
            model.base_price7 = SIString.TryDec(row["base_price7"]);
            model.base_price8 = SIString.TryDec(row["base_price8"]);
            model.new_oper_id = SIString.TryStr(row["new_oper_id"]);
            model.modify_oper_id = SIString.TryStr(row["modify_oper_id"]);
            model.en_gift = SIString.TryStr(row["en_gift"]);
            model.promote_flag = SIString.TryStr(row["promote_flag"]);
            return model;
        }

    }
}