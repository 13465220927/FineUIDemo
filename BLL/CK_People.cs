using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// ҵ���߼���CK_People ��ժҪ˵����
	/// </summary>
	public class CK_People
	{
		private readonly TSM.DAL.CK_People dal=new TSM.DAL.CK_People();
		public CK_People()
		{}
		#region  ��Ա����

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
		public bool Exists(int CK_PeopleID)
		{
			return dal.Exists(CK_PeopleID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(TSM.Model.CK_People model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(TSM.Model.CK_People model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CK_PeopleID)
		{
			
			dal.Delete(CK_PeopleID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public TSM.Model.CK_People GetModel(int CK_PeopleID)
		{
			
			return dal.GetModel(CK_PeopleID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public TSM.Model.CK_People GetModelByCache(int CK_PeopleID)
		{
			
			string CacheKey = "CK_PeopleModel-" + CK_PeopleID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CK_PeopleID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.CK_People)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TSM.Model.CK_People> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TSM.Model.CK_People> DataTableToList(DataTable dt)
		{
			List<TSM.Model.CK_People> modelList = new List<TSM.Model.CK_People>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.CK_People model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.CK_People();
					if(dt.Rows[n]["CK_PeopleID"].ToString()!="")
					{
						model.CK_PeopleID=int.Parse(dt.Rows[n]["CK_PeopleID"].ToString());
					}
					model.CK_PeopleName=dt.Rows[n]["CK_PeopleName"].ToString();
					model.CK_PhoneNo=dt.Rows[n]["CK_PhoneNo"].ToString();
					model.CK_Comment=dt.Rows[n]["CK_Comment"].ToString();
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
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

