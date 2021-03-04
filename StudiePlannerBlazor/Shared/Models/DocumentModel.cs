using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StudiePlannerBlazor.Shared.Models
{
    public class DocumentModel
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
    }
}
