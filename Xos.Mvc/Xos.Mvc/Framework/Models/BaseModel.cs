using System;
using System.ComponentModel.DataAnnotations;

namespace Xos.Mvc.Framework.Models
{
    public class BaseModel : IDisposable
    {
        // Flag: Has Dispose already been called? 
        private bool _disposed;

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


        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
            }

            // Free any unmanaged objects here. 
            //
            _disposed = true;
        }
    }
}