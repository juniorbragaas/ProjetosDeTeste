using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TGCTE.Entities
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { set; get; }
        public string UserName { set; get; }
        public string LoginName { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public string ContactNo { set; get; }
        public string Address { set; get; }
        public int IsApporved { set; get; }
        public int Status { set; get; }
        public int TotalCnt { set; get; }
    }
}
