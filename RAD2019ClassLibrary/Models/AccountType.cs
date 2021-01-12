using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD2019ClassLibrary.Models
{
   
        [Table("AccountType")]
        public class AccountType
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int AccountTypeID { get; set; }
            public string TypeName { get; set; }
            public string Conditons { get; set; }
        }
    
}
