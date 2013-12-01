using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// ���ݷ�����:CK_Type
	/// </summary>
	public partial class CK_Type
	{
		public CK_Type()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQLite.GetMaxID("CK_TypeID", "CK_Type"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int CK_TypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CK_Type");
			strSql.Append(" where CK_TypeID=@CK_TypeID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4)};
			parameters[0].Value = CK_TypeID;

			return DbHelperSQLite.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Maticsoft.Model.CK_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CK_Type(");
			strSql.Append("CK_TypeID,CK_TypeName)");
			strSql.Append(" values (");
			strSql.Append("@CK_TypeID,@CK_TypeName)");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4),
					new SQLiteParameter("@CK_TypeName", DbType.String,2147483647)};
			parameters[0].Value = model.CK_TypeID;
			parameters[1].Value = model.CK_TypeName;

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
		public bool Update(Maticsoft.Model.CK_Type model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CK_Type set ");
			strSql.Append("CK_TypeName=@CK_TypeName");
			strSql.Append(" where CK_TypeID=@CK_TypeID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@CK_TypeName", DbType.String,2147483647),
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4)};
			parameters[0].Value = model.CK_TypeName;
			parameters[1].Value = model.CK_TypeID;

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
		public bool Delete(int CK_TypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Type ");
			strSql.Append(" where CK_TypeID=@CK_TypeID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4)};
			parameters[0].Value = CK_TypeID;

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
		public bool DeleteList(string CK_TypeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CK_Type ");
			strSql.Append(" where CK_TypeID in ("+CK_TypeIDlist + ")  ");
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
		public Maticsoft.Model.CK_Type GetModel(int CK_TypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CK_TypeID,CK_TypeName from CK_Type ");
			strSql.Append(" where CK_TypeID=@CK_TypeID ");
			SQLiteParameter[] parameters = {
					new SQLiteParameter("@CK_TypeID", DbType.Int32,4)};
			parameters[0].Value = CK_TypeID;

			Maticsoft.Model.CK_Type model=new Maticsoft.Model.CK_Type();
			DataSet ds=DbHelperSQLite.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CK_TypeID"].ToString()!="")
				{
					model.CK_TypeID=int.Parse(ds.Tables[0].Rows[0]["CK_TypeID"].ToString());
				}
				model.CK_TypeName=ds.Tables[0].Rows[0]["CK_TypeName"].ToString();
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
			strSql.Append("select CK_TypeID,CK_TypeName ");
			strSql.Append(" FROM CK_Type ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "CK_Type";
			parameters[1].Value = "CK_TypeID";
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

