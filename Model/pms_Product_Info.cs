using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Product_Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Product_Info
	{
		public pms_Product_Info()
		{}
		#region Model
		private int _productinfoid;
		private int _productbatchid;
		private int _customerrequireid;
		private int _producttypeid;
		private int? _productstrucid;
		private int? _productmaterid;
		private int? _productindustid;
		private string _productinfoname;
		private string _productphotonum;
		private string _productstandard;
		private decimal _productweight;
		private string _orderquantity;
		private string _contoursize;
		private string _remarks;
        private string _批次名称;
        private string _产品名称;
        private string _顾客类型;
        private string _顾客名称;
        private string _顾客要求;
        private string _产品结构;
        private string _产品材质;
        private string _所在行业;
        private string _图号;
        private string _规范;
        private string _净重;
        private string _日期;
        private string _订单量;
        private string _备注;
        private string _附件名称;
        private string _附件地址;
        private string _上传节点;
        private string _上传时间;
        private string _上传人;
        private string _商务联系人;
        private string _商务联系电话;
        private string _商务联系邮箱;
        private string _质量联系人;
        private string _质量联系电话;
        private string _质量联系邮箱;
        private string _ApprovalStatus;
        private int _QuotationInfoID;
        private string _最终客户;
        private string _报价人;
        private string _报价邮箱;
        private string _营销员邮箱;
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
		public int ProductBatchID
		{
			set{ _productbatchid=value;}
			get{return _productbatchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CustomerRequireID
		{
			set{ _customerrequireid=value;}
			get{return _customerrequireid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ProductTypeID
		{
			set{ _producttypeid=value;}
			get{return _producttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductStrucID
		{
			set{ _productstrucid=value;}
			get{return _productstrucid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductMaterID
		{
			set{ _productmaterid=value;}
			get{return _productmaterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProductIndustID
		{
			set{ _productindustid=value;}
			get{return _productindustid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductInfoName
		{
			set{ _productinfoname=value;}
			get{return _productinfoname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductPhotoNum
		{
			set{ _productphotonum=value;}
			get{return _productphotonum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductStandard
		{
			set{ _productstandard=value;}
			get{return _productstandard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ProductWeight
		{
			set{ _productweight=value;}
			get{return _productweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderQuantity
		{
			set{ _orderquantity=value;}
			get{return _orderquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContourSize
		{
			set{ _contoursize=value;}
			get{return _contoursize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string 批次名称
        {
            set { _批次名称 = value; }
            get { return _批次名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 产品名称
        {
            set { _产品名称 = value; }
            get { return _产品名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 顾客类型
        {
            set { _顾客类型 = value; }
            get { return _顾客类型; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 顾客名称
        {
            set { _顾客名称 = value; }
            get { return _顾客名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 顾客要求
        {
            set { _顾客要求 = value; }
            get { return _顾客要求; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 产品结构
        {
            set { _产品结构 = value; }
            get { return _产品结构; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 产品材质
        {
            set { _产品材质 = value; }
            get { return _产品材质; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 所在行业
        {
            set { _所在行业 = value; }
            get { return _所在行业; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 图号
        {
            set { _图号 = value; }
            get { return _图号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 规范
        {
            set { _规范 = value; }
            get { return _规范; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 净重
        {
            set { _净重 = value; }
            get { return _净重; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 日期
        {
            set { _日期 = value; }
            get { return _日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 订单量
        {
            set { _订单量 = value; }
            get { return _订单量; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 附件名称
        {
            set { _附件名称 = value; }
            get { return _附件名称; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 附件地址
        {
            set { _附件地址 = value; }
            get { return _附件地址; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 上传节点
        {
            set { _上传节点 = value; }
            get { return _上传节点; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 上传时间
        {
            set { _上传时间 = value; }
            get { return _上传时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 上传人
        {
            set { _上传人 = value; }
            get { return _上传人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 商务联系人
        {
            set { _商务联系人 = value; }
            get { return _商务联系人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 商务联系电话
        {
            set { _商务联系电话 = value; }
            get { return _商务联系电话; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 商务联系邮箱
        {
            set { _商务联系邮箱 = value; }
            get { return _商务联系邮箱; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 质量联系人
        {
            set { _质量联系人 = value; }
            get { return _质量联系人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 质量联系电话
        {
            set { _质量联系电话 = value; }
            get { return _质量联系电话; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 质量联系邮箱
        {
            set { _质量联系邮箱 = value; }
            get { return _质量联系邮箱; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApprovalStatus
        {
            set { _ApprovalStatus = value; }
            get { return _ApprovalStatus; }
        } 
        /// <summary>
        /// 
        /// </summary>
        public int QuotationInfoID
        {
            set { _QuotationInfoID = value; }
            get { return _QuotationInfoID; }
        } 
        /// <summary>
        /// 
        /// </summary>
        public string 最终客户
        {
            set { _最终客户 = value; }
            get { return _最终客户; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 报价人
        {
            set { _报价人 = value; }
            get { return _报价人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 报价邮箱
        {
            set { _报价邮箱 = value; }
            get { return _报价邮箱; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 营销员邮箱
        {
            set { _营销员邮箱 = value; }
            get { return _营销员邮箱; }
        }

		#endregion Model

	}
}

