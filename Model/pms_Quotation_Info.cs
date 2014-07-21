using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Quotation_Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Quotation_Info
	{
		public pms_Quotation_Info()
		{}
		#region Model
		private int _quotationinfoid;
		private int _productinfoid;
        private int _UserInfoID;
		private int _quotationdepart;
		private decimal _knifecharges;
		private decimal _toolcharges;
		private decimal _quotationprice;
		private string _approvalstatus;
		private DateTime _quotationtime;
		private decimal? _sprayingcharges;
		private decimal? _packingcharges;
		private decimal? _testingcharges;
		private decimal? _transportcharges;
        private decimal? _cost;
        private decimal? _charge;
        private int _ApprovalInfoID;
        private int _approvorID;
        private int _KnifeRate;
        private int _PackingRate;
        private int _QuotationRate;
        private int _TestingRate;
        private int _ToolRate;
        private int _TransportRate;
        private string _Remarks;
        private string _SprayingDescrib;
        private string _PackingDescrib;
        private string _TestingDescrib;
        private string _TransportDescrib;
        private string _ChargeDescrib;
        private string _KinfeDescrib;
        private string _ToolsDescrib;
        private decimal _刀具费用;
        private string _刀具信息;
        private decimal _工装费用;
        private string _工装信息;
        private decimal _检测费用;
        private string _检测信息;
        private decimal _运输费用;
        private string _运费信息;
        private decimal _喷涂费用;
        private string _喷涂信息;
        private decimal _包装费用;
        private string _包装信息;
        private decimal _加工费用;
        private string _加工信息;
        private string _审批状态;
        private decimal _净重;
		/// <summary>
		/// 
		/// </summary>
		public int QuotationInfoID
		{
			set{ _quotationinfoid=value;}
			get{return _quotationinfoid;}
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
        public int UserInfoID
        {
            set { _UserInfoID = value; }
            get { return _UserInfoID; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int QuotationDepart
		{
			set{ _quotationdepart=value;}
			get{return _quotationdepart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal KnifeCharges
		{
			set{ _knifecharges=value;}
			get{return _knifecharges;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ToolCharges
		{
			set{ _toolcharges=value;}
			get{return _toolcharges;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal QuotationPrice
		{
			set{ _quotationprice=value;}
			get{return _quotationprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ApprovalStatus
		{
			set{ _approvalstatus=value;}
			get{return _approvalstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime QuotationTime
		{
			set{ _quotationtime=value;}
			get{return _quotationtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SprayingCharges
		{
			set{ _sprayingcharges=value;}
			get{return _sprayingcharges;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PackingCharges
		{
			set{ _packingcharges=value;}
			get{return _packingcharges;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TestingCharges
		{
			set{ _testingcharges=value;}
			get{return _testingcharges;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TransportCharges
		{
			set{ _transportcharges=value;}
			get{return _transportcharges;}
		}
        /// <summary>
        /// 
        /// </summary>
        public decimal? Charge
        {
            set { _charge = value; }
            get { return _charge; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Cost
        {
            set { _cost = value; }
            get { return _cost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ApprovalInfoID
        {
            set { _ApprovalInfoID = value; }
            get { return _ApprovalInfoID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int approvorID
        {
            set { _approvorID = value; }
            get { return _approvorID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int KnifeRate
        {
            set { _KnifeRate = value; }
            get { return _KnifeRate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PackingRate
        {
            set { _PackingRate = value; }
            get { return _PackingRate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int QuotationRate
        {
            set { _QuotationRate = value; }
            get { return _QuotationRate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TestingRate
        {
            set { _TestingRate = value; }
            get { return _TestingRate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ToolRate
        {
            set { _ToolRate = value; }
            get { return _ToolRate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TransportRate
        {
            set { _TransportRate = value; }
            get { return _TransportRate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _Remarks = value; }
            get { return _Remarks; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SprayingDescrib
        {
            set { _SprayingDescrib = value; }
            get { return _SprayingDescrib; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PackingDescrib
        {
            set { _PackingDescrib = value; }
            get { return _PackingDescrib; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestingDescrib
        {
            set { _TestingDescrib = value; }
            get { return _TestingDescrib; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TransportDescrib
        {
            set { _TransportDescrib = value; }
            get { return _TransportDescrib; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KinfeDescrib
        {
            set { _KinfeDescrib = value; }
            get { return _KinfeDescrib; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolsDescrib
        {
            set { _ToolsDescrib = value; }
            get { return _ToolsDescrib; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChargeDescrib
        {
            set { _ChargeDescrib = value; }
            get { return _ChargeDescrib; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal 刀具费用
        {
            set { _刀具费用 = value; }
            get { return _刀具费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 刀具信息
        {
            set { _刀具信息 = value; }
            get { return _刀具信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal 工装费用
        {
            set { _工装费用 = value; }
            get { return _工装费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 工装信息
        {
            set { _工装信息 = value; }
            get { return _工装信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal 包装费用
        {
            set { _包装费用 = value; }
            get { return _包装费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 包装信息
        {
            set { _包装信息 = value; }
            get { return _包装信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal 检测费用
        {
            set { _检测费用 = value; }
            get { return _检测费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 检测信息
        {
            set { _检测信息 = value; }
            get { return _检测信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal 运输费用
        {
            set { _运输费用 = value; }
            get { return _运输费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 运费信息
        {
            set { _运费信息 = value; }
            get { return _运费信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal 喷涂费用
        {
            set { _喷涂费用 = value; }
            get { return _喷涂费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 喷涂信息
        {
            set { _喷涂信息 = value; }
            get { return _喷涂信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal 加工费用
        {
            set { _加工费用 = value; }
            get { return _加工费用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 加工信息
        {
            set { _加工信息 = value; }
            get { return _加工信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 审批状态
        {
            set { _审批状态 = value; }
            get { return _审批状态; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal 净重
        {
            set { _净重 = value; }
            get { return _净重; }
        }

		#endregion Model

	}
}

