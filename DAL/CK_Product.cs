using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// ���ݷ�����:CK_Product
	/// </summary>
	public partial class CK_Product
	{
		public CK_Product()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("ProductID", "CK_Product"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ProductID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_Product");
			strSql.Append(" where ProductID=@ProductID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ProductID", DbType.Int32,4)};
			parameters[0].Value = ProductID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Maticsoft.Model.CK_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_Product(");
			strSql.Append("ProductID,CK_TypeID,ProductName,Price,Unit)");
			strSql.Append(" values (");
			strSql.Append("@ProductID,@CK_TypeID,@ProductName,@Price,@Unit)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ProductID", DbType.Int32,4),
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4),
					new SQLiteParameter("@ProductName", DbType.String,2147483647),
					new SQLiteParameter("@Price", DbType.Decimal,8),
					new SQLiteParameter("@Unit", DbType.String,2147483647)};
			parameters[0].Value = model.ProductID;
			parameters[1].Value = model.CK_TypeID;
			parameters[2].Value = model.ProductName;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.Unit;

            object obj = DbHelperSQLite.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.CK_Product model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_Product set ");
			strSql.Append("CK_TypeID=@CK_TypeID,");
			strSql.Append("ProductName=@ProductName,");
			strSql.Append("Price=@Price,");
			strSql.Append("Unit=@Unit");
			strSql.Append(" where ProductID=@ProductID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4),
					new SQLiteParameter("@ProductName", DbType.String,2147483647),
					new SQLiteParameter("@Price", DbType.Decimal,8),
					new SQLiteParameter("@Unit", DbType.String,2147483647),
					new SQLiteParameter("@ProductID", DbType.Int32,4)};
			parameters[0].Value = model.CK_TypeID;
			parameters[1].Value = model.ProductName;
			parameters[2].Value = model.Price;
			parameters[3].Value = model.Unit;
			parameters[4].Value = model.ProductID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ProductID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Product ");
			strSql.Append(" where ProductID=@ProductID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ProductID", DbType.Int32,4)};
			parameters[0].Value = ProductID;

			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string ProductIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Product ");
			strSql.Append(" where ProductID in ("+ProductIDlist + ")  ");
			int rows=DbHelperSQLite.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.CK_Product GetModel(int ProductID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductID,CK_TypeID,ProductName,Price,Unit from CK_Product ");
			strSql.Append(" where ProductID=@ProductID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@ProductID", DbType.Int32,4)};
			parameters[0].Value = ProductID;

			Maticsoft.Model.CK_Product model=new Maticsoft.Model.CK_Product();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProductID"].ToString()!="")
				{
					model.ProductID=int.Parse(ds.Tables[0].Rows[0]["ProductID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CK_TypeID"].ToString()!="")
				{
					model.CK_TypeID=int.Parse(ds.Tables[0].Rows[0]["CK_TypeID"].ToString());
				}
				model.ProductName=ds.Tables[0].Rows[0]["ProductName"].ToString();
				if(ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				model.Unit=ds.Tables[0].Rows[0]["Unit"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProductID,CK_TypeID,ProductName,Price,Unit ");
            strSql.Append(" FROM CK_Product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" ORDER BY CK_TypeID");
			return DbHelperSQLite.Query(strSql.ToString());
		}


        public DataSet GetOnlyList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ProductID,ProductName ");
            strSql.Append(" FROM CK_Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }
		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@tblName", DbType.VarChar, 255),
					new SQLiteParameter("@fldName", DbType.VarChar, 255),
					new SQLiteParameter("@PageSize", DbType.Int32),
					new SQLiteParameter("@PageIndex", DbType.Int32),
					new SQLiteParameter("@IsReCount", DbType.bit),
					new SQLiteParameter("@OrderType", DbType.bit),
					new SQLiteParameter("@strWhere", DbType.VarChar,1000),
					};
			parameters[0].Value = "CK_Product";
			parameters[1].Value = "ProductID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQLite.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

