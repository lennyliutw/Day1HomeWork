namespace Day1HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Day1HomeWork.Filter;
    using System.Web.Mvc;
 

    [Table("AccountBook")]
    public partial class AccountBook
    {
       
      
        public Guid Id { get; set; }

        [DisplayName("收支別")]
        public int Categoryyy { get; set; }

        [DisplayName("金額")]
        [Range (0,Int32.MaxValue , ErrorMessage = "{0} 必需為正整數")]
        public int Amounttt { get; set; }

        [DisplayName("日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [BeforeToday(ErrorMessage ="ok")]
        public DateTime Dateee { get; set; }

        [DisplayName("備註")]
        [Required]
        [StringLength(100, ErrorMessage = "{0} 字數不可大於100")]
        public string Remarkkk { get; set; }

        [DisplayName("備註")]
        [Required]
        [StringLength(30)]
        public string Remarkshort
        {
            get
            {
                if (this.Remarkkk.Length > 30)
                {
                    return this.Remarkkk.Substring(0, 30) + " ...";
                }
                else
                {
                    return this.Remarkkk;
                }
            }

        }

        [DisplayName("分類")]
        public string CategoryCht
        {
            get
            {
                if (this.Categoryyy == 1)
                {
                    return "1.收入";
                }
                else
                {
                    return "2.支出";
                }
            }
        }
    }
}
