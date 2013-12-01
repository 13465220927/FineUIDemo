using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// CK_People
	/// </summary>
	public partial class CK_People
	{
		private readonly Maticsoft.DAL.CK_People dal=new Maticsoft.DAL.CK_People();
		public CK_People()
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
		public bool Exists(int PeopleID)
		{
			return dal.Exists(PeopleID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Maticsoft.Model.CK_People model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.CK_People model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int PeopleID)
		{
			
			return dal.Delete(PeopleID);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool DeleteList(string PeopleIDlist )
		{
			return dal.DeleteList(PeopleIDlist );
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Maticsoft.Model.CK_People GetModel(int PeopleID)
		{
			
			return dal.GetModel(PeopleID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Maticsoft.Model.CK_People GetModelByCache(int PeopleID)
		{
			
			string CacheKey = "CK_PeopleModel-" + PeopleID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PeopleID);
					if (objModel != null)
					{
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.CK_People)objModel;
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
		public List<Maticsoft.Model.CK_People> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.CK_People> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.CK_People> modelList = new List<Maticsoft.Model.CK_People>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.CK_People model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.CK_People();
					if(dt.Rows[n]["PeopleID"].ToString()!="")
					{
						model.PeopleID=int.Parse(dt.Rows[n]["PeopleID"].ToString());
					}
					model.PeopleName=dt.Rows[n]["PeopleName"].ToString();
					model.Mobile=dt.Rows[n]["Mobile"].ToString();
					model.Comment=dt.Rows[n]["Comment"].ToString();
					if(dt.Rows[n]["obligate"].ToString()!="")
					{
						model.obligate=int.Parse(dt.Rows[n]["obligate"].ToString());
					}
					if(dt.Rows[n]["obligate2"].ToString()!="")
					{
						model.obligate2=DateTime.Parse(dt.Rows[n]["obligate2"].ToString());
					}
					model.obligate3=dt.Rows[n]["obligate3"].ToString();
					if(dt.Rows[n]["obligate4"].ToString()!="")
					{
						model.obligate4=decimal.Parse(dt.Rows[n]["obligate4"].ToString());
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
		/// ��ҳ��ȡ�����б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

