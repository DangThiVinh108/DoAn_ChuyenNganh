using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoffeeManagement
{
    public class DataProvider
    {
        SqlConnection connection = new SqlConnection();
        public DataProvider()
        {
            try
            {
                connection.ConnectionString = @"Data Source=DESKTOP-GP47KE0;Initial Catalog=CoffeeManagementSystem;Integrated Security=True";
                connection.Open();
            }
            catch { }
        }


        public DataTable LoadTable()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_Table";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public void ResetTable(string MABAN)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Reset_Table";
            command.Parameters.AddWithValue("@MABAN", SqlDbType.NVarChar).Value = MABAN;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ThemHoaDonBan(string MANV, string MABAN, DateTime NGAYHDBH, float TONGTIEN)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                if (connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_Insert_HOADONBANHANG";
                command.Parameters.AddWithValue("@MANV", SqlDbType.VarChar).Value = MANV;
                command.Parameters.AddWithValue("@MABAN", SqlDbType.NVarChar).Value = MABAN;
                command.Parameters.AddWithValue("@NGAYHDBH", SqlDbType.DateTime).Value = NGAYHDBH;
                command.Parameters.AddWithValue("@TONGTIEN", SqlDbType.Float).Value = TONGTIEN;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public int GetMaHohaDon_byTable(string MaBan)
        {
            try
            {
                DataTable data = new DataTable();
                SqlCommand command = new SqlCommand();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetMaHoaDon_byTable";
                command.Parameters.AddWithValue("@MaBan", SqlDbType.NVarChar).Value = MaBan;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();

                if (data.Rows.Count > 0)
                {
                    return int.Parse(data.Rows[0][0].ToString());
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public void ThemChiTietHoaDon(int MaHoaDon, string MaHH, int SoLuong)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SP_Insert_ChiTietHoaDon";
                command.Parameters.AddWithValue("@MaHoaDon", SqlDbType.Int).Value = MaHoaDon;
                command.Parameters.AddWithValue("@MaHH", SqlDbType.NVarChar).Value = MaHH;
                command.Parameters.AddWithValue("@SoLuong", SqlDbType.Int).Value = SoLuong;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {

            }
           
        }
        public void ThemLoaiHang(string MALH, string TENLH, string MOTA)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Them_LoaiHang";
            command.Parameters.AddWithValue("@MALH", SqlDbType.VarChar).Value = MALH;
            command.Parameters.AddWithValue("@TENLH", SqlDbType.NVarChar).Value = TENLH;
            command.Parameters.AddWithValue("@MOTA", SqlDbType.NVarChar).Value = MOTA;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CapNhatTTBan(string MABAN, string TRANGTHAI)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CapNhat_TTBan";
            command.Parameters.AddWithValue("@MABAN", SqlDbType.VarChar).Value = MABAN;
            command.Parameters.AddWithValue("@TRANGTHAI", SqlDbType.NVarChar).Value = TRANGTHAI;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CapNhatTTHoaDon(int MAHDBH, int TRANGTHAI)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CapNhat_TTHoaDon";
            command.Parameters.AddWithValue("@MAHD", SqlDbType.Int).Value = MAHDBH;
            command.Parameters.AddWithValue("@TRANGTHAI", SqlDbType.Int).Value = TRANGTHAI;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CapNhatLoaiHang(string MALH_CU,string MALH, string TENLH, string MOTA)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CapNhat_LoaiHang";
            command.Parameters.AddWithValue("@MALH_CU", SqlDbType.VarChar).Value = MALH_CU;
            command.Parameters.AddWithValue("@MALH", SqlDbType.VarChar).Value = MALH;
            command.Parameters.AddWithValue("@TENLH", SqlDbType.NVarChar).Value = TENLH;
            command.Parameters.AddWithValue("@MOTA", SqlDbType.NVarChar).Value = MOTA;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void XoaLoaiHang (string MALH)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Xoa_LoaiHang";
            command.Parameters.AddWithValue("@MALH", SqlDbType.VarChar).Value = MALH;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ThemHangHoa(string MALH, string MAHH, string TENHH,string GIASP)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Them_HangHoa";
            command.Parameters.AddWithValue("@MAHH", SqlDbType.VarChar).Value = MAHH;
            command.Parameters.AddWithValue("@MALH", SqlDbType.VarChar).Value = MALH;
            command.Parameters.AddWithValue("@TENHH", SqlDbType.NVarChar).Value = TENHH;
            command.Parameters.AddWithValue("@GIASP", SqlDbType.Float).Value = GIASP;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CapNhatHangHoa (string MALH,string MAHH_CU,string MAHH, string TENHH, string GIASP)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CapNhatHangHoa";
            command.Parameters.AddWithValue("@MAHH_CU", SqlDbType.VarChar).Value = MAHH_CU;
            command.Parameters.AddWithValue("@MALH", SqlDbType.VarChar).Value = MALH;
            command.Parameters.AddWithValue("@MAHH", SqlDbType.VarChar).Value = MAHH;
            command.Parameters.AddWithValue("@TENHH", SqlDbType.NVarChar).Value = TENHH;
            command.Parameters.AddWithValue("@GIASP", SqlDbType.Float).Value = GIASP;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void XoaHangHoa(string MAHH)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Xoa_HangHoa";
            command.Parameters.AddWithValue("@MAHH", SqlDbType.VarChar).Value = MAHH;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ThemBan(string MABAN, string TENBAN, string TRANGTHAI)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Them_Ban";
            command.Parameters.AddWithValue("@MABAN", SqlDbType.NVarChar).Value = MABAN;
            command.Parameters.AddWithValue("@TENBAN", SqlDbType.NVarChar).Value = TENBAN;
            command.Parameters.AddWithValue("@TRANGTHAI", SqlDbType.NVarChar).Value = TRANGTHAI;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CapNhatBan(string MABAN_CU, string MABAN, string TENBAN, string TRANGTHAI)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CapNhat_Ban";
            command.Parameters.AddWithValue("@MABAN_CU", SqlDbType.NVarChar).Value = MABAN_CU;
            command.Parameters.AddWithValue("@MABAN", SqlDbType.NVarChar).Value = MABAN;
            command.Parameters.AddWithValue("@TENBAN", SqlDbType.NVarChar).Value = TENBAN;
            command.Parameters.AddWithValue("@TRANGTHAI", SqlDbType.NVarChar).Value = TRANGTHAI;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void XoaBan(string MABAN)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Xoa_Ban";
            command.Parameters.AddWithValue("@MABAN", SqlDbType.NVarChar).Value = MABAN;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ThemCa(string MACLV, string TENCALV, DateTime GIOBD,DateTime GIOKT, string SOTIEN)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Them_Ca";
            command.Parameters.AddWithValue("@MACLV", SqlDbType.VarChar).Value = MACLV;
            command.Parameters.AddWithValue("@TENCLV", SqlDbType.NVarChar).Value = TENCALV;
            command.Parameters.AddWithValue("@GIOBD", SqlDbType.Time).Value = GIOBD;
            command.Parameters.AddWithValue("@GIOKT", SqlDbType.Time).Value = GIOKT;
            command.Parameters.AddWithValue("@SOTIEN", SqlDbType.Float).Value = SOTIEN;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CapNhatCa(string MACLV_CU,string MACLV, string TENCALV, DateTime GIOBD, DateTime GIOKT, string SOTIEN)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CapNhat_Ca";
            command.Parameters.AddWithValue("@MACLV_CU", SqlDbType.VarChar).Value = MACLV_CU;
            command.Parameters.AddWithValue("@MACLV", SqlDbType.VarChar).Value = MACLV;
            command.Parameters.AddWithValue("@TENCLV", SqlDbType.NVarChar).Value = TENCALV;
            command.Parameters.AddWithValue("@GIOBD", SqlDbType.Time).Value = GIOBD;
            command.Parameters.AddWithValue("@GIOKT", SqlDbType.Time).Value = GIOKT;
            command.Parameters.AddWithValue("@SOTIEN", SqlDbType.Float).Value = SOTIEN;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void XoaCa(string MACLV)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Xoa_Ca";
            command.Parameters.AddWithValue("@MACLV", SqlDbType.VarChar).Value = MACLV;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void XoaLuong(string MACLV,string MANV)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Xoa_Luong";
            command.Parameters.AddWithValue("@MACLV", SqlDbType.VarChar).Value = MACLV;
            command.Parameters.AddWithValue("@MANV", SqlDbType.VarChar).Value = MANV;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ThemLuong(string KYLUONG, string MANV,  int TONGCALAM,int THANHTIEN)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Them_luong";
            command.Parameters.AddWithValue("@MANV", SqlDbType.VarChar).Value = MANV;
            command.Parameters.AddWithValue("@KYLUONG", SqlDbType.VarChar).Value = KYLUONG;
            command.Parameters.AddWithValue("@TONGCALAM", SqlDbType.Int).Value = TONGCALAM;
            command.Parameters.AddWithValue("@THANHTIEN", SqlDbType.Int).Value = THANHTIEN;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CapNhatLuong(string MANV_CU,string MANV, string KYLUONG, int TONGCALAM, int THANHTIEN)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Them_luong";
            command.Parameters.AddWithValue("@MANV_CU", SqlDbType.VarChar).Value = MANV_CU;
            command.Parameters.AddWithValue("@MANV", SqlDbType.VarChar).Value = MANV;
            command.Parameters.AddWithValue("@KYLUONG", SqlDbType.VarChar).Value = KYLUONG;
            command.Parameters.AddWithValue("@TONGCALAM", SqlDbType.Int).Value = TONGCALAM;
            command.Parameters.AddWithValue("@THANHTIEN", SqlDbType.Int).Value = THANHTIEN;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void XoaNhanVien(string MANV)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Xoa_NhanVien";
            command.Parameters.AddWithValue("@MANV", SqlDbType.VarChar).Value = MANV;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ThemNhanVien(string MANV, string TENNV, string SDT, string DIACHI, string CHUCVU, string NGAYBD, bool QUYEN, string MATKHAU, bool GIOITINH)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Them_NhanVien";
            command.Parameters.AddWithValue("@MANV", SqlDbType.VarChar).Value = MANV;
            command.Parameters.AddWithValue("@TENNV", SqlDbType.NVarChar).Value = TENNV;
            command.Parameters.AddWithValue("@SDT", SqlDbType.NVarChar).Value = SDT;
            command.Parameters.AddWithValue("@DIACHI", SqlDbType.NVarChar).Value = DIACHI;
            command.Parameters.AddWithValue("@CHUCVU", SqlDbType.NVarChar).Value = CHUCVU;
            command.Parameters.AddWithValue("@MATKHAU", SqlDbType.VarChar).Value = MATKHAU;
            command.Parameters.AddWithValue("@QUYEN", SqlDbType.Bit).Value = QUYEN;
            command.Parameters.AddWithValue("@NGAYVAO", SqlDbType.Date).Value = NGAYBD;
            command.Parameters.AddWithValue("@GIOITINH", SqlDbType.Bit).Value = GIOITINH;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CapNhatNhanVien(string MANV_CU, string MANV, string TENNV, string SDT, string DIACHI,string CHUCVU, string NGAYBD, bool QUYEN, string MATKHAU, bool GIOITINH)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_CapNhat_NhanVien";
            command.Parameters.AddWithValue("@MANV_CU", SqlDbType.VarChar).Value = MANV_CU;
            command.Parameters.AddWithValue("@MANV", SqlDbType.VarChar).Value = MANV;
            command.Parameters.AddWithValue("@TENNV", SqlDbType.NVarChar).Value = TENNV;
            command.Parameters.AddWithValue("@SDT", SqlDbType.NVarChar).Value = SDT;
            command.Parameters.AddWithValue("@DIACHI", SqlDbType.NVarChar).Value = DIACHI;
            command.Parameters.AddWithValue("@CHUCVU", SqlDbType.NVarChar).Value = CHUCVU;
            command.Parameters.AddWithValue("@MATKHAU", SqlDbType.VarChar).Value = MATKHAU;
            command.Parameters.AddWithValue("@QUYEN", SqlDbType.Bit).Value = QUYEN;
            command.Parameters.AddWithValue("@NGAYVAO", SqlDbType.Date).Value = NGAYBD;
            command.Parameters.AddWithValue("@GIOITINH", SqlDbType.Bit).Value = GIOITINH;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable LoadTypeOfCommodity()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_TypeOfCommodity";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable LoadAllCommodity()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_AllCommodity";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable LoadCommodity(string TENLH)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_Commodity";
            command.Parameters.AddWithValue("@TENLH", SqlDbType.NVarChar).Value = TENLH;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable LoadBill(string MABAN)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_Bill";
            command.Parameters.AddWithValue("@MABAN", SqlDbType.NVarChar).Value = MABAN;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable LoadEmployee()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_Employees";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable LoadCommodityByType(string MALH)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_CommodityByType";
            command.Parameters.AddWithValue("@MALH", SqlDbType.NVarChar).Value = MALH;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable LoadWorkingShift()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_WorkingShift";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable LoadSalaryEmployeeDetail()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_SalaryEmployeeDetails";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable LoadSalaryEmployeeDetailsByEmployeeCode(string MANV_TENNV)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_SalaryEmployeeDetailsByEmployeeCode";
            command.Parameters.AddWithValue("@MANV_TENNV", SqlDbType.NVarChar).Value = MANV_TENNV;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public DataTable LoadTableWhere(string MABAN)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_Table_Where";
            command.Parameters.AddWithValue("@MABAN", SqlDbType.NVarChar).Value = MABAN;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }


        public DataTable LoadBillWhere(string MAHDBH)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Load_Bill_Where";
            command.Parameters.AddWithValue("@MAHDBH", SqlDbType.NVarChar).Value = MAHDBH;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            return data;
        }

        public void ClearTable(string TENBAN)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_Clear_Table";
            command.Parameters.AddWithValue("@TENBAN", SqlDbType.NVarChar).Value = TENBAN;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
