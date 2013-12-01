using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// T_ACL_User
	/// </summary>
	public partial class T_ACL_User
	{
		private readonly Maticsoft.DAL.T_ACL_User dal=new Maticsoft.DAL.T_ACL_User();
		public T_ACL_User()
		{}
		#region  Method

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Maticsoft.Model.T_ACL_User model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.T_ACL_User model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.T_ACL_User GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Maticsoft.Model.T_ACL_User GetModelByCache(int ID)
		{
			
			string CacheKey = "T_ACL_UserModel-" + ID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.T_ACL_User)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.T_ACL_User> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.T_ACL_User> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.T_ACL_User> modelList = new List<Maticsoft.Model.T_ACL_User>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.T_ACL_User model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.T_ACL_User();
					if(dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["PID"].ToString()!="")
					{
						model.PID=int.Parse(dt.Rows[n]["PID"].ToString());
					}
					model.Name=dt.Rows[n]["Name"].ToString();
					model.Password=dt.Rows[n]["Password"].ToString();
					model.FullName=dt.Rows[n]["FullName"].ToString();
					if(dt.Rows[n]["IsExpire"].ToString()!="")
					{
						if((dt.Rows[n]["IsExpire"].ToString()=="1")||(dt.Rows[n]["IsExpire"].ToString().ToLower()=="true"))
						{
						model.IsExpire=true;
						}
						else
						{
							model.IsExpire=false;
						}
					}
					model.Title=dt.Rows[n]["Title"].ToString();
					model.IdentityCard=dt.Rows[n]["IdentityCard"].ToString();
					model.MobilePhone=dt.Rows[n]["MobilePhone"].ToString();
					model.OfficePhone=dt.Rows[n]["OfficePhone"].ToString();
					model.HomePhone=dt.Rows[n]["HomePhone"].ToString();
					model.Email=dt.Rows[n]["Email"].ToString();
					model.Address=dt.Rows[n]["Address"].ToString();
					model.CustomField=dt.Rows[n]["CustomField"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

