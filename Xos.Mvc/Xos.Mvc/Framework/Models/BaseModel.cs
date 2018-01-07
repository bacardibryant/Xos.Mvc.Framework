using System;
using System.ComponentModel.DataAnnotations;

namespace Xos.Mvc.Framework.Models
{
    /// <summary>
    /// A base model with standard model properties. Application models inheriting from this class get these
    /// properties automatically without the need to add them each time.
    /// ID property is not included as not all models use the same data type to store identity fields.
    /// </summary>
    public abstract class BaseModel
    {
        // EF 6 AND EF Core
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Display(Name = "Created By")]
        [StringLength(250, ErrorMessage = "Created by cannot exceed 150 characters.")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Last Modified By")]
        [StringLength(250, ErrorMessage = "Last modified by cannot exceed 150 characters.")]
        public string LastModifiedBy { get; set; }

        [Display(Name = "Last Modified On")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        public DateTime LastModifiedOn { get; set; }

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted { get; set; }
    }
}