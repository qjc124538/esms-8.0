using Esms.Ddd.Domain;
using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Account.Domain
{
     /// <summary>
    /// 系统用户定义
    ///</summary>
    [SugarTable("S_USER")]
    public class SUser
    {
        /// <summary>
        /// 内码 
        ///</summary>
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true)]
        public decimal Id { get; set; }
        /// <summary>
        /// 用户ID 
        ///</summary>
        [SugarColumn(ColumnName = "USERID")]
        public string Userid { get; set; }
        /// <summary>
        /// 用户名称 
        ///</summary>
        [SugarColumn(ColumnName = "USERNAME")]
        public string Username { get; set; }

        /// <summary>
        /// 状态 
        ///</summary>
        [SugarColumn(ColumnName = "STATE")]
        [JsonConverter(typeof(CustomStringBooleanConverter))]
        public string State { get; set; }
        /// <summary>
        /// 备注 
        ///</summary>
        [SugarColumn(ColumnName = "REMARK")]
        public string Remark { get; set; }
        /// <summary>
        /// 更新人 
        ///</summary>
        [SugarColumn(ColumnName = "UPDATEUSER")]
        public string Updateuser { get; set; }
        /// <summary>
        /// 更新日期 
        ///</summary>
        [SugarColumn(ColumnName = "UPDATEDATE")]
        public DateTime? Updatedate { get; set; }
        /// <summary>
        /// 公司 
        ///</summary>
        [SugarColumn(ColumnName = "CORP_NO")]
        public decimal? CorpNo { get; set; }
        /// <summary>
        /// 用户类型 
        ///</summary>
        [SugarColumn(ColumnName = "TYPE")]
        public string Type { get; set; }
        /// <summary>
        /// 部门 
        ///</summary>
        [SugarColumn(ColumnName = "WORKRESOURCE_NO")]
        public decimal WorkresourceNo { get; set; }
        /// <summary>
        /// 定义人 
        ///</summary>
        [SugarColumn(ColumnName = "DEFUSER")]
        public string Defuser { get; set; }
        /// <summary>
        /// 定义日期 
        ///</summary>
        [SugarColumn(ColumnName = "DEFDATE")]
        public DateTime? Defdate { get; set; }
        /// <summary>
        /// 岗位定义 
        ///</summary>
        [SugarColumn(ColumnName = "POST_DEF")]
        public string PostDef { get; set; }


        /// <summary>
        /// 电话 
        ///</summary>
        [SugarColumn(ColumnName = "TELEPHONE")]
        public string Telephone { get; set; }
        /// <summary>
        /// 电邮 
        ///</summary>
        [SugarColumn(ColumnName = "EMAIL")]
        public string Email { get; set; }
        /// <summary>
        /// 电邮密码
        ///</summary>
        [SugarColumn(ColumnName = "EMAIL_PASSWORD")]
        public string Email_Password { get; set; }

        /// <summary>
        /// 所属子公司 
        ///</summary>
        [SugarColumn(ColumnName = "WORK_RESOURCE_NO2")]
        public decimal? WorkResourceNo2 { get; set; }
        /// <summary>
        /// 所属公司 
        ///</summary>
        [SugarColumn(ColumnName = "WORK_RESOURCE_NO3")]
        public decimal? WorkResourceNo3 { get; set; }

        /// <summary>
        /// 英文名 
        ///</summary>
        [SugarColumn(ColumnName = "USERNAME_EN")]
        public string UsernameEn { get; set; }

        /// <summary>
        /// 用户操作语言切换 
        ///</summary>
        [SugarColumn(ColumnName = "USER_LANGUAGE")]
        public decimal? UserLanguage { get; set; }
        /// <summary>
        /// 最后一次更新密码日期 
        ///</summary>
        [SugarColumn(ColumnName = "LAST_PWD_CHANGE_DATE")]
        public DateTime? LastPwdChangeDate { get; set; }

        /// <summary>
        /// 是否公共账号8-是 9-不是  默认值 9
        /// </summary>
        [SugarColumn(ColumnName = "PUBLIC_ACC")]
        [JsonConverter(typeof(CustomStringBooleanConverter))]
        public string PublicAcc { get; set; }


    }
}
