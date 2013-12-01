using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CK_Product
	/// </summary>
	public partial class CK_Product
	{
		private readonly Maticsoft.DAL.CK_Product dal=new Maticsoft.DAL.CK_Product();
		public CK_Product()
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
		public bool Exists(int ProductID)
		{
			return dal.Exists(ProductID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Maticsoft.Model.CK_Product model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.CK_Product model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ProductID)
		{
			
			return dal.Delete(ProductID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string ProductIDlist )
		{
			return dal.DeleteList(ProductIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.CK_Product GetModel(int ProductID)
		{
			
			return dal.GetModel(ProductID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Maticsoft.Model.CK_Product GetModelByCache(int ProductID)
		{
			
			string CacheKey = "CK_ProductModel-" + ProductID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductID);
					if (objModel != null)
					{
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.CK_Product)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public DataSet GetOnlyList(string strWhere)
		{
            return dal.GetOnlyList(strWhere);
		}
        
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.CK_Product> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.CK_Product> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CK_Product> modelList = new List<Maticsoft.Model.CK_Product>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CK_Product model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CK_Product();
					if(dt.Rows[n]["ProductID"].ToString()!="")
					{
						model.ProductID=int.Parse(dt.Rows[n]["ProductID"].ToString());
					}
					if(dt.Rows[n]["CK_TypeID"].ToString()!="")
					{
						model.CK_TypeID=int.Parse(dt.Rows[n]["CK_TypeID"].ToString());
					}
					model.ProductName=dt.Rows[n]["ProductName"].ToString();
					if(dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
					}
					model.Unit=dt.Rows[n]["Unit"].ToString();
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

