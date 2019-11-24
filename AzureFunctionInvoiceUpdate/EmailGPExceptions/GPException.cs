using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace EmailGPExceptions
{
    public class GPException
    {
       
        public string Reference{ get; set; }
        public DateTime? TxDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string WarehouseName { get; set; }
        public string ClientGroup { get; set; }
        public string ClientGroupName { get; set; }
        public string AreaCode { get; set; }
        public string AreaDescription { get; set; }
        public string RepCode { get; set; }
        public string RepName { get; set; }
        public string Account { get; set; }
        public string ucARCallFrequency { get; set; }
        public string ucARRep { get; set; }
        public string ucARSegment { get; set; }
        public string ulARType { get; set; }
        public string ItemCode { get; set; }
        public string itemgroup { get; set; }
        public string ItemDescription { get; set; }
        public string Branch { get; set; }
        public string Warehousecode { get; set; }
        public double ActualQuantity { get; set; }
        public double ActualSalesValue { get; set; }
        public double Profit { get; set; }
        public double Cost { get; set; }
        public double ProfitPerc { get; set; }
        public double RequiredGP { get; set; }
        public double ActualPrice { get; set; }
        public double PriceVariance { get; set; }
        public string PriceComment { get; set; }
        public double AccountMobilePrice { get; set; }
        public double BranchMobilePrice { get; set; }
        public double ValueChainPrice { get; set; }
        public double DiffActAMP { get; set; }
        public double DiffActBMP { get; set; }
        public double DiffActVCP { get; set; }
        public double RequiredGPValue { get; set; }
        public double LostGPValue { get; set; }
        public string Region { get; set; }
        public string WarehouseType { get; set; }
        public string Channel { get; set; }

        public GPException(DataRow row)
        {
            this.Reference = row["Reference"].ToString();
            this.TxDate = Convert.ToDateTime(row["TxDate"]);
            this.Code = row["Code"].ToString();
            this.Name = row["Name"].ToString();
            this.WarehouseName = row["WarehouseName"].ToString();
            this.Branch = row["Branch"].ToString();
            this.Warehousecode = row["Warehousecode"].ToString();
            this.Region = row["Region"].ToString();
            this.WarehouseType = row["WarehouseType"].ToString();
            this.Channel = row["Channel"].ToString();
            this.ClientGroup = row["ClientGroup"].ToString();
            this.ClientGroupName = row["ClientGroupName"].ToString();
            this.AreaCode = row["AreaCode"].ToString();
            this.AreaDescription = row["AreaDescription"].ToString();
            this.RepCode = row["RepCode"].ToString();
            this.RepName = row["RepName"].ToString();
            this.Account = row["Account"].ToString();
            this.ucARCallFrequency = row["ucARCallFrequency"].ToString();
            this.ucARRep = row["ucARRep"].ToString();
            this.ucARSegment = row["ucARSegment"].ToString();
            this.ulARType = row["ulARType"].ToString();
            this.ItemCode = row["ItemCode"].ToString();
            this.itemgroup = row["itemgroup"].ToString();
            this.ItemDescription = row["ItemDescription"].ToString();
           
            this.ActualQuantity = Convert.ToDouble(row["ActualQuantity"]);
            this.ActualSalesValue = Convert.ToDouble(row["ActualSalesValue"]);
            this.Profit = Convert.ToDouble(row["Profit"]);
            this.Cost = Convert.ToDouble(row["Cost"]);
            this.ProfitPerc = Convert.ToDouble(row["ProfitPerc"]);
            this.RequiredGP = Convert.ToDouble(row["RequiredGP"]);
            this.RequiredGPValue = Convert.ToDouble(row["RequiredGPValue"]);
            this.LostGPValue = Convert.ToDouble(row["LostGPValue"]);
            this.ActualPrice = Convert.ToDouble(row["ActualPrice"]);
            this.PriceVariance = Convert.ToDouble(row["PriceVariance"]);
            this.PriceComment = row["PriceComment"].ToString();
            this.AccountMobilePrice = Convert.ToDouble(row["AccountMobilePrice"]);
            this.BranchMobilePrice = Convert.ToDouble(row["BranchMobilePrice"]);
            this.ValueChainPrice = Convert.ToDouble(row["ValueChainPrice"]);
            this.DiffActAMP = Convert.ToDouble(row["DiffActAMP"]);
            this.DiffActBMP = Convert.ToDouble(row["DiffActBMP"]);
            this.DiffActVCP = Convert.ToDouble(row["DiffActVCP"]);
            
        }
    }
}
