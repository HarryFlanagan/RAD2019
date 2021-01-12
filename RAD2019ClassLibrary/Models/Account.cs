using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD2019ClassLibrary.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }
        public string AccountName { get; set; }

        [DataType(DataType.Date)] //Implements HTML 5 Datetime Picker
        public DateTime InceptionDate { get; set; }

        [ForeignKey("FK_Customer")]
        public int CustomerID { get; set; }

        public double CurrentBalance { get; set; }

        [ForeignKey("FK_AccountType")]
        public int AccountTypeID { get; set; }

        public virtual Customer FK_Customer { get; set; }
        public virtual AccountType FK_AccountType { get; set; }


    }
}
