using System;
namespace TSM.Model
{
	/// <summary>
	/// ʵ����CK_People ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class CK_People
	{
		public CK_People()
		{}
		#region Model
		private int _ck_peopleid;
		private string _ck_peoplename;
		private string _ck_phoneno;
		private string _ck_comment;
		/// <summary>
		/// 
		/// </summary>
		public int CK_PeopleID
		{
			set{ _ck_peopleid=value;}
			get{return _ck_peopleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CK_PeopleName
		{
			set{ _ck_peoplename=value;}
			get{return _ck_peoplename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CK_PhoneNo
		{
			set{ _ck_phoneno=value;}
			get{return _ck_phoneno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CK_Comment
		{
			set{ _ck_comment=value;}
			get{return _ck_comment;}
		}
		#endregion Model

	}
}

