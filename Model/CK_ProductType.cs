using System;
namespace TSM.Model
{
	/// <summary>
	/// ʵ����CK_ProductType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class CK_ProductType
	{
		public CK_ProductType()
		{}
		#region Model
		private int _ck_producttypeid;
		private string _ck_producttypename;
		/// <summary>
		/// 
		/// </summary>
		public int CK_ProductTypeID
		{
			set{ _ck_producttypeid=value;}
			get{return _ck_producttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CK_ProductTypeName
		{
			set{ _ck_producttypename=value;}
			get{return _ck_producttypename;}
		}
		#endregion Model

	}
}

