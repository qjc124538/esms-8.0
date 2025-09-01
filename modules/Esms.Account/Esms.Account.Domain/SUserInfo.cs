using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Account.Domain
{
    /// <summary>
    /// 用户信息
    ///</summary>
    [SugarTable("S_USER_INFO")]
    public class SUserInfo
    {
        /// <summary>
        /// 用户ID  来源于 S_USER.USERID
        ///</summary>
        [SugarColumn(ColumnName = "USERID", IsPrimaryKey = true)]
        public string Userid { get; set; }

        /// <summary>
        /// 密钥 
        ///</summary>
        [SugarColumn(ColumnName = "SECRETKEY")]
        public string Secretkey { get; set; }

        /// <summary>
        /// 密钥种子 
        ///</summary>
        [SugarColumn(ColumnName = "SEED")]
        public string Seed { get; set; }
    }
}
