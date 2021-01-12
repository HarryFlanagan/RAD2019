using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD2019ClassLibrary.Models
{
    public enum transactionType
    { 
        Lodgment = 0, 
        Widthdrawal = 1 
    }


    [Table("Transactons")]
    public class Transcations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }
        public transactionType TransactionType { get; set; }

        public double Amount { get; set; }

        [DataType(DataType.Date)] //Implements HTML 5 Datetime Picker
        public DateTime transactionDate { get; set; }

        [ForeignKey("FK_Account")]
        public int AccountID { get; set; }
        public virtual Account FK_Account{ get; set; }
    }
}
