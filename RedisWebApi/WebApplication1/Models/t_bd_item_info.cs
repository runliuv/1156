using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRedis.Models
{
    public class t_bd_item_info
    {
        private string _item_no;

        private string _item_subno = "0";

        private string _item_name;

        private string _item_subname;

        private string _item_clsno;

        private string _item_brand;

        private string _item_brandname;

        private string _unit_no;

        private string _item_size;

        private decimal _price;

        private decimal _base_price;

        private decimal _sale_price;

        private string _combine_sta = "0";

        private string _status = "1";

        private string _display_flag = "1";

        private int? _po_cycle = 0;

        private int? _so_cycle = 0;

        private string _automin_flag = "1";

        private string _en_dis = "0";

        private string _change_price = "0";

        private decimal? _purchase_tax = 0.17M;

        private decimal? _sale_tax = 0.17M;

        private decimal? _purchase_spec = 1M;

        private decimal? _shipment_spec = 1M;

        private string _item_supcust = string.Empty;

        private string _main_supcust = "0";

        private string _item_stock = "0";

        private DateTime? _build_date;

        private DateTime? _modify_date;

        private DateTime? _stop_date;

        private string _abc = "C";

        private string _branch_price = "0";

        private string _item_rem;

        private decimal _vip_price;

        private decimal _sale_min_price;

        private string _com_flag;

        private string _vip_acc_flag;

        private decimal? _vip_acc_num;

        private string _dpfm_type = "0";

        private decimal? _return_rate;

        private string _update_date;

        private string _pro_code1;

        private string _pro_code2;

        private string _pro_code3;

        private string _pro_code4;

        private string _pro_code5;

        private string _pro_code6;

        private string _item_picture;

        private string _sale_flag = "0";

        private decimal _scheme_price;

        private decimal _vip_price2;

        private decimal _vip_price3;

        private decimal _vip_price4;

        private decimal _vip_price5;

        private decimal? _valid_days = 0M;

        private string _memo;

        private string _item_com = "0";

        private string _product_area;

        private string _measure_flag;

        private string _item_sup_flag;

        private decimal? _sup_rate;

        private string _picture_type;

        private decimal? _base_price1;

        private decimal? _base_price2;

        private decimal? _base_price3;

        private decimal? _base_price4;

        private decimal? _base_price5;

        private decimal? _base_price6;

        private decimal? _base_price7;

        private decimal? _base_price8;

        private string _new_oper_id;

        private string _modify_oper_id;

        private string _en_gift = "0";

        private string _promote_flag = "Y";
        public string item_no
        {
            get { return _item_no; }
            set { _item_no = value; }
        }
        public string item_subno
        {
            get { return _item_subno; }
            set { _item_subno = value; }
        }
        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; }
        }
        public string item_subname
        {
            get { return _item_subname; }
            set { _item_subname = value; }
        }
        public string item_clsno
        {
            get { return _item_clsno; }
            set { _item_clsno = value; }
        }
        public string item_brand
        {
            get { return _item_brand; }
            set { _item_brand = value; }
        }
        public string item_brandname
        {
            get { return _item_brandname; }
            set { _item_brandname = value; }
        }
        public string unit_no
        {
            get { return _unit_no; }
            set { _unit_no = value; }
        }
        public string item_size
        {
            get { return _item_size; }
            set { _item_size = value; }
        }
        public decimal price
        {
            get { return _price; }
            set { _price = value; }
        }
        public decimal base_price
        {
            get { return _base_price; }
            set { _base_price = value; }
        }
        public decimal sale_price
        {
            get { return _sale_price; }
            set { _sale_price = value; }
        }
        public string combine_sta
        {
            get { return _combine_sta; }
            set { _combine_sta = value; }
        }
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string display_flag
        {
            get { return _display_flag; }
            set { _display_flag = value; }
        }
        public int? po_cycle
        {
            get { return _po_cycle; }
            set { _po_cycle = value; }
        }
        public int? so_cycle
        {
            get { return _so_cycle; }
            set { _so_cycle = value; }
        }
        public string automin_flag
        {
            get { return _automin_flag; }
            set { _automin_flag = value; }
        }
        public string en_dis
        {
            get { return _en_dis; }
            set { _en_dis = value; }
        }
        public string change_price
        {
            get { return _change_price; }
            set { _change_price = value; }
        }
        public decimal? purchase_tax
        {
            get { return _purchase_tax; }
            set { _purchase_tax = value; }
        }
        public decimal? sale_tax
        {
            get { return _sale_tax; }
            set { _sale_tax = value; }
        }
        public decimal? purchase_spec
        {
            get { return _purchase_spec; }
            set { _purchase_spec = value; }
        }
        public decimal? shipment_spec
        {
            get { return _shipment_spec; }
            set { _shipment_spec = value; }
        }
        public string item_supcust
        {
            get { return _item_supcust; }
            set { _item_supcust = value; }
        }
        public string main_supcust
        {
            get { return _main_supcust; }
            set { _main_supcust = value; }
        }
        public string item_stock
        {
            get { return _item_stock; }
            set { _item_stock = value; }
        }
        public DateTime? build_date
        {
            get { return _build_date; }
            set { _build_date = value; }
        }
        public DateTime? modify_date
        {
            get { return _modify_date; }
            set { _modify_date = value; }
        }
        public DateTime? stop_date
        {
            get { return _stop_date; }
            set { _stop_date = value; }
        }
        public string abc
        {
            get { return _abc; }
            set { _abc = value; }
        }
        public string branch_price
        {
            get { return _branch_price; }
            set { _branch_price = value; }
        }
        public string item_rem
        {
            get { return _item_rem; }
            set { _item_rem = value; }
        }
        public decimal vip_price
        {
            get { return _vip_price; }
            set { _vip_price = value; }
        }
        public decimal sale_min_price
        {
            get { return _sale_min_price; }
            set { _sale_min_price = value; }
        }
        public string com_flag
        {
            get { return _com_flag; }
            set { _com_flag = value; }
        }
        public string vip_acc_flag
        {
            get { return _vip_acc_flag; }
            set { _vip_acc_flag = value; }
        }
        public decimal? vip_acc_num
        {
            get { return _vip_acc_num; }
            set { _vip_acc_num = value; }
        }
        public string dpfm_type
        {
            get { return _dpfm_type; }
            set { _dpfm_type = value; }
        }
        public decimal? return_rate
        {
            get { return _return_rate; }
            set { _return_rate = value; }
        }
        public string update_date
        {
            get { return _update_date; }
            set { _update_date = value; }
        }
        public string pro_code1
        {
            get { return _pro_code1; }
            set { _pro_code1 = value; }
        }
        public string pro_code2
        {
            get { return _pro_code2; }
            set { _pro_code2 = value; }
        }
        public string pro_code3
        {
            get { return _pro_code3; }
            set { _pro_code3 = value; }
        }
        public string pro_code4
        {
            get { return _pro_code4; }
            set { _pro_code4 = value; }
        }
        public string pro_code5
        {
            get { return _pro_code5; }
            set { _pro_code5 = value; }
        }
        public string pro_code6
        {
            get { return _pro_code6; }
            set { _pro_code6 = value; }
        }
        public string item_picture
        {
            get { return _item_picture; }
            set { _item_picture = value; }
        }
        public string sale_flag
        {
            get { return _sale_flag; }
            set { _sale_flag = value; }
        }
        public decimal scheme_price
        {
            get { return _scheme_price; }
            set { _scheme_price = value; }
        }
        public decimal vip_price2
        {
            get { return _vip_price2; }
            set { _vip_price2 = value; }
        }
        public decimal vip_price3
        {
            get { return _vip_price3; }
            set { _vip_price3 = value; }
        }
        public decimal vip_price4
        {
            get { return _vip_price4; }
            set { _vip_price4 = value; }
        }
        public decimal vip_price5
        {
            get { return _vip_price5; }
            set { _vip_price5 = value; }
        }
        public decimal? valid_days
        {
            get { return _valid_days; }
            set { _valid_days = value; }
        }
        public string memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        public string item_com
        {
            get { return _item_com; }
            set { _item_com = value; }
        }
        public string product_area
        {
            get { return _product_area; }
            set { _product_area = value; }
        }
        public string measure_flag
        {
            get { return _measure_flag; }
            set { _measure_flag = value; }
        }
        public string item_sup_flag
        {
            get { return _item_sup_flag; }
            set { _item_sup_flag = value; }
        }
        public decimal? sup_rate
        {
            get { return _sup_rate; }
            set { _sup_rate = value; }
        }
        public string picture_type
        {
            get { return _picture_type; }
            set { _picture_type = value; }
        }
        public decimal? base_price1
        {
            get { return _base_price1; }
            set { _base_price1 = value; }
        }
        public decimal? base_price2
        {
            get { return _base_price2; }
            set { _base_price2 = value; }
        }
        public decimal? base_price3
        {
            get { return _base_price3; }
            set { _base_price3 = value; }
        }
        public decimal? base_price4
        {
            get { return _base_price4; }
            set { _base_price4 = value; }
        }
        public decimal? base_price5
        {
            get { return _base_price5; }
            set { _base_price5 = value; }
        }
        public decimal? base_price6
        {
            get { return _base_price6; }
            set { _base_price6 = value; }
        }
        public decimal? base_price7
        {
            get { return _base_price7; }
            set { _base_price7 = value; }
        }
        public decimal? base_price8
        {
            get { return _base_price8; }
            set { _base_price8 = value; }
        }
        public string new_oper_id
        {
            get { return _new_oper_id; }
            set { _new_oper_id = value; }
        }
        public string modify_oper_id
        {
            get { return _modify_oper_id; }
            set { _modify_oper_id = value; }
        }
        public string en_gift
        {
            get { return _en_gift; }
            set { _en_gift = value; }
        }
        public string promote_flag
        {
            get { return _promote_flag; }
            set { _promote_flag = value; }
        }
        private bool _isNew = false;
        /// <summary>
        /// 是否新记录.
        /// </summary>
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }


    }
}