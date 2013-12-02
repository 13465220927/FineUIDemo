using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// ҵ���߼���CK_ProductType ��ժҪ˵����
	/// </summary>
	public class CK_ProductType
	{
		private readonly TSM.DAL.CK_ProductType dal=new TSM.DAL.CK_ProductType();
		public CK_ProductType()
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
		public bool Exists(int CK_ProductTypeID)
		{
			return dal.Exists(CK_ProductTypeID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(TSM.Model.CK_ProductType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(TSM.Model.CK_ProductType model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CK_ProductTypeID)
		{
			
			dal.Delete(CK_ProductTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public TSM.Model.CK_ProductType GetModel(int CK_ProductTypeID)
		{
			
			return dal.GetModel(CK_ProductTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public TSM.Model.CK_ProductType GetModelByCache(int CK_ProductTypeID)
		{
			
			string CacheKey = "CK_ProductTypeModel-" + CK_ProductTypeID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CK_ProductTypeID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.CK_ProductType)objModel;
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
		public List<TSM.Model.CK_ProductType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TSM.Model.CK_ProductType> DataTableToList(DataTable dt)
		{
			List<TSM.Model.CK_ProductType> modelList = new List<TSM.Model.CK_ProductType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.CK_ProductType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.CK_ProductType();
					if(dt.Rows[n]["CK_ProductTypeID"].ToString()!="")
					{
						model.CK_ProductTypeID=int.Parse(dt.Rows[n]["CK_ProductTypeID"].ToString());
					}
					model.CK_ProductTypeName=dt.Rows[n]["CK_ProductTypeName"].ToString();
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

