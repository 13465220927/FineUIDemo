using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// ҵ���߼���CK_Product ��ժҪ˵����
	/// </summary>
	public class CK_Product
	{
		private readonly TSM.DAL.CK_Product dal=new TSM.DAL.CK_Product();
		public CK_Product()
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
		public bool Exists(int CK_ProductID)
		{
			return dal.Exists(CK_ProductID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(TSM.Model.CK_Product model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(TSM.Model.CK_Product model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CK_ProductID)
		{
			
			dal.Delete(CK_ProductID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public TSM.Model.CK_Product GetModel(int CK_ProductID)
		{
			
			return dal.GetModel(CK_ProductID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public TSM.Model.CK_Product GetModelByCache(int CK_ProductID)
		{
			
			string CacheKey = "CK_ProductModel-" + CK_ProductID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CK_ProductID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.CK_Product)objModel;
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
		public List<TSM.Model.CK_Product> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TSM.Model.CK_Product> DataTableToList(DataTable dt)
		{
			List<TSM.Model.CK_Product> modelList = new List<TSM.Model.CK_Product>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.CK_Product model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.CK_Product();
					if(dt.Rows[n]["CK_ProductID"].ToString()!="")
					{
						model.CK_ProductID=int.Parse(dt.Rows[n]["CK_ProductID"].ToString());
					}
					if(dt.Rows[n]["CK_ProductTypeID"].ToString()!="")
					{
						model.CK_ProductTypeID=int.Parse(dt.Rows[n]["CK_ProductTypeID"].ToString());
					}
					model.CK_ProductName=dt.Rows[n]["CK_ProductName"].ToString();
					if(dt.Rows[n]["CK_ProductPrice"].ToString()!="")
					{
						model.CK_ProductPrice=decimal.Parse(dt.Rows[n]["CK_ProductPrice"].ToString());
					}
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetList(PageSize, PageIndex, strWhere);
        }

		#endregion  ��Ա����
	}
}

