using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Attachment 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Attachment
	{
		public pms_Attachment()
		{}
		#region Model
		private int _attachmentid;
		private int _productinfoid;
		private int _uploaduid;
		private string _attachmentname;
		private string _attachmentaddr;
		private string _uploadpermission;
		private DateTime _uploadtime;
		/// <summary>
		/// 
		/// </summary>
		public int AttachmentID
		{
			set{ _attachmentid=value;}
			get{return _attachmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductInfoID
		{
			set{ _productinfoid=value;}
			get{return _productinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UploadUid
		{
			set{ _uploaduid=value;}
			get{return _uploaduid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttachmentName
		{
			set{ _attachmentname=value;}
			get{return _attachmentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttachmentAddr
		{
			set{ _attachmentaddr=value;}
			get{return _attachmentaddr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UploadPermission
		{
			set{ _uploadpermission=value;}
			get{return _uploadpermission;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UploadTime
		{
			set{ _uploadtime=value;}
			get{return _uploadtime;}
		}
		#endregion Model

	}
}

