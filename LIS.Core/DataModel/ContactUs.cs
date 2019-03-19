﻿using LIS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Core.DataModel {
    [Table("ContactUs")]
  public  class ContactUs:BaseEntity
    {
        [Key]
        public string ContactUsID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string WebSite { get; set; }
        public string Message { get; set; }
    }
}
