namespace Day1HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("AccountBook")]
    public partial class AccountBook
    {
       
        [DisplayName("編號")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("收支別")]
        public int Categoryyy { get; set; }

        [DisplayName("金額")]
        [ ]
        public int Amounttt { get; set; }

        [DisplayName("日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Dateee { get; set; }

        [DisplayName("備註")]
        [Required]
        [StringLength(500)]
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
