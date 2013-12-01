using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
	/// <summary>
	/// TB_DictType
	/// </summary>
	public partial class TB_DictType
	{
		private readonly Maticsoft.DAL.TB_DictType dal=new Maticsoft.DAL.TB_DictType();
		public TB_DictType()
		{}
		#region  Method
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Maticsoft.Model.TB_DictType model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Maticsoft.Model.TB_DictType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(string ID)
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
		public Maticsoft.Model.TB_DictType GetModel(string ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ�����
		/// </summary>
		public Maticsoft.Model.TB_DictType GetModelByCache(string ID)
		{
			
			string CacheKey = "TB_DictTypeModel-" + ID;
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
			return (Maticsoft.Model.TB_DictType)objModel;
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
		public List<Maticsoft.Model.TB_DictType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Maticsoft.Model.TB_DictType> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.TB_DictType> modelList = new List<Maticsoft.Model.TB_DictType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.TB_DictType model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.TB_DictType();
					model.ID=dt.Rows[n]["ID"].ToString();
					model.Name=dt.Rows[n]["Name"].ToString();
					model.Remark=dt.Rows[n]["Remark"].ToString();
					model.Seq=dt.Rows[n]["Seq"].ToString();
					if(dt.Rows[n]["Editor"].ToString()!="")
					{
						model.Editor=int.Parse(dt.Rows[n]["Editor"].ToString());
					}
					if(dt.Rows[n]["LastUpdated"].ToString()!="")
					{
						model.LastUpdated=DateTime.Parse(dt.Rows[n]["LastUpdated"].ToString());
					}
					model.PID=dt.Rows[n]["PID"].ToString();
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

