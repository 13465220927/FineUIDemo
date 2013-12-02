using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// ҵ���߼���CK_Payment ��ժҪ˵����
	/// </summary>
	public class CK_Payment
	{
		private readonly TSM.DAL.CK_Payment dal=new TSM.DAL.CK_Payment();
		public CK_Payment()
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
		public bool Exists(int CK_PaymentID)
		{
			return dal.Exists(CK_PaymentID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(TSM.Model.CK_Payment model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(TSM.Model.CK_Payment model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int CK_PaymentID)
		{
			
			dal.Delete(CK_PaymentID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public TSM.Model.CK_Payment GetModel(int CK_PaymentID)
		{
			
			return dal.GetModel(CK_PaymentID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public TSM.Model.CK_Payment GetModelByCache(int CK_PaymentID)
		{
			
			string CacheKey = "CK_PaymentModel-" + CK_PaymentID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CK_PaymentID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.CK_Payment)objModel;
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
		public List<TSM.Model.CK_Payment> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<TSM.Model.CK_Payment> DataTableToList(DataTable dt)
		{
			List<TSM.Model.CK_Payment> modelList = new List<TSM.Model.CK_Payment>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.CK_Payment model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.CK_Payment();
					if(dt.Rows[n]["CK_PaymentID"].ToString()!="")
					{
						model.CK_PaymentID=int.Parse(dt.Rows[n]["CK_PaymentID"].ToString());
					}
					if(dt.Rows[n]["CK_PeopleID"].ToString()!="")
					{
						model.CK_PeopleID=int.Parse(dt.Rows[n]["CK_PeopleID"].ToString());
					}
					if(dt.Rows[n]["CK_SendGoodsID"].ToString()!="")
					{
						model.CK_SendGoodsID=int.Parse(dt.Rows[n]["CK_SendGoodsID"].ToString());
					}
					if(dt.Rows[n]["CK_PayDate"].ToString()!="")
					{
						model.CK_PayDate=DateTime.Parse(dt.Rows[n]["CK_PayDate"].ToString());
					}
					if(dt.Rows[n]["CK_PayMoney"].ToString()!="")
					{
						model.CK_PayMoney=decimal.Parse(dt.Rows[n]["CK_PayMoney"].ToString());
					}
					model.CK_PayComment=dt.Rows[n]["CK_PayComment"].ToString();
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

